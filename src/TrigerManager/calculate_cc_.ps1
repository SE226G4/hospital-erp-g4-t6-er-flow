$file = Get-ChildItem -Recurse -Filter "TriageManager.cs" | Select-Object -First 1
$content = Get-Content $file.FullName
$reportData = New-Object System.Collections.Generic.List[PSObject]

$inFunction = $false
$currentFunc = $null
$braceCount = 0

for ($i = 0; $i -lt $content.Count; $i++) {
    $line = $content[$i].Trim()
    
    if ([string]::IsNullOrEmpty($line)) {
        if ($inFunction) { $currentFunc.LOC++ }
        continue
    }

    if (!$inFunction -and $line -match '(?<name>\w+)\s*\((?<params>[^\)]*)\)\s*(?:\{|=>|$)') {
        if ($Matches['name'] -match '^(if|while|for|foreach|switch|catch)$') { continue }
        
        $funcName = $Matches['name']
        $paramStr = $Matches['params'].Trim()
        $paramCount = if ($paramStr -eq "") { 0 } else { ($paramStr -split ',').Count }
        
        $currentFunc = [PSCustomObject]@{
            "Name"   = $funcName
            "Start"  = $i + 1
            "Params" = $paramCount
            "Body"   = $line + "`n"
            "LOC"    = 1
        }

        if ($line -match '=>') {
            $cleanBody = [regex]::Replace($currentFunc.Body, '//.*|(?s)/\*.*?\*/', '')
            $ccMatches = [regex]::Matches($cleanBody, '\b(if|else\s+if|for|foreach|while|case)\b|&&|\|\||\?')
            
            $currentFunc | Add-Member -MemberType NoteProperty -Name "Complexity" -Value ($ccMatches.Count + 1)
            $currentFunc | Add-Member -MemberType NoteProperty -Name "End" -Value ($i + 1)
            $reportData.Add($currentFunc)
            $currentFunc = $null
            continue
        }

        $inFunction = $true
        $braceCount = ($line.ToCharArray() | Where-Object {$_ -eq '{'}).Count - ($line.ToCharArray() | Where-Object {$_ -eq '}'}).Count
        continue
    }

    if ($inFunction -and $currentFunc -ne $null) {
        $currentFunc.Body += $content[$i] + "`n"
        $currentFunc.LOC++
        
        $braceCount += ($content[$i].ToCharArray() | Where-Object {$_ -eq '{'}).Count - ($content[$i].ToCharArray() | Where-Object {$_ -eq '}'}).Count
        
        if ($braceCount -eq 0 -and $currentFunc.Body -match '\{') {
            $cleanBody = [regex]::Replace($currentFunc.Body, '//.*|(?s)/\*.*?\*/', '')
            $ccMatches = [regex]::Matches($cleanBody, '\b(if|else\s+if|for|foreach|while|case)\b|&&|\|\||\?')
            
            $currentFunc | Add-Member -MemberType NoteProperty -Name "Complexity" -Value ($ccMatches.Count + 1)
            $currentFunc | Add-Member -MemberType NoteProperty -Name "End" -Value ($i + 1)
            $reportData.Add($currentFunc)
            
            $inFunction = $false
            $currentFunc = $null
        }
    }
}

$rows = foreach ($row in $reportData) {
    $cc = [int]$row.Complexity
    $display = if ($cc -gt 11) { "<b>$cc &#9888;</b>" } else { "$cc" }
    $style = if ($cc -gt 11) { "style='background-color:#ffcccc; color:red; font-weight:bold;'" } else { "" }
    
    "<tr>
        <td>Program::$($row.Name)</td>
        <td>$($row.Start)</td>
        <td>$($row.End)</td>
        <td $style>$display</td>
        <td>$($row.LOC)</td>
        <td>$($row.Params)</td>
    </tr>"
}

$html = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        table { border-collapse: collapse; width: 80%; margin: 30px auto; font-family: 'Segoe UI', Tahoma, sans-serif; box-shadow: 0 0 20px rgba(0,0,0,0.1); }
        th { background: #2c3e50; color: white; padding: 15px; text-align: center; }
        td { border: 1px solid #ddd; padding: 12px; text-align: center; }
        tr:nth-child(even) { background-color: #f9f9f9; }
        h2 { text-align: center; color: #2c3e50; }
    </style>
</head>
<body>
    <h2>Code Complexity Analysis Report</h2>
    <table>
        <tr><th>Function Name</th><th>Start Line</th><th>End Line</th><th>Complexity</th><th>LOC</th><th>Params</th></tr>
        $($rows -join "")
    </table>
</body>
</html>
"@

$html | Out-File "ComplexityReport.html" -Encoding utf8
Invoke-Item "ComplexityReport.html"




# [Console]::OutputEncoding = [System.Text.Encoding]::UTF8
# $threshold = 11

# Get-ChildItem -Recurse -Filter *.cs | ForEach-Object {
#     $content = Get-Content $_.FullName -Raw
    
#     # Use regex matches to find ALL occurrences in the entire file content
#     $pattern = '\b(if|else if|for|foreach|while|case)\b|&&|\|\|'
#     $matches = [regex]::Matches($content, $pattern)
    
#     # Total count of all operators found + 1 base path
#     $cc = $matches.Count + 1
    
#     $status = if ($cc -gt $threshold) { "WARNING: CC is $cc" } else { "CC: $cc" }
    
#     Write-Host "File: $($_.Name) | $status"
# }