New-Item -Path .\Artifacts -ItemType Directory -Force
New-Item -Path .\Artifacts\RJTX-DynamoDBFormulaTester-x64 -ItemType Directory -Force
New-Item -Path .\Artifacts\RJTX-DynamoDBFormulaTester-x86 -ItemType Directory -Force
New-Item -Path .\Artifacts\RJTX-DynamoDBFormulaTester-osx -ItemType Directory -Force

Copy-Item -Path .\DynamoDBFormulaTester\bin\Release\netcoreapp3.1\win10-x64\publish\*.exe -Destination .\Artifacts\RJTX-DynamoDBFormulaTester-x64

Copy-Item -Path .\DynamoDBFormulaTester\bin\Release\netcoreapp3.1\win10-x86\publish\*.exe -Destination .\Artifacts\RJTX-DynamoDBFormulaTester-x86

Copy-Item -Path .\DynamoDBFormulaTester\bin\Release\netcoreapp3.1\osx.10.10-x64\publish\DynamoDBFormulaTester -Destination .\Artifacts\RJTX-DynamoDBFormulaTester-osx

Compress-7Zip ".\Artifacts\RJTX-DynamoDBFormulaTester-x64\" -ArchiveFileName ".\Artifacts\RJTX-DynamoDBFormulaTester-x64.zip" -Format Zip
Compress-7Zip ".\Artifacts\RJTX-DynamoDBFormulaTester-x86\" -ArchiveFileName ".\Artifacts\RJTX-DynamoDBFormulaTester-x86.zip" -Format Zip
Compress-7Zip ".\Artifacts\RJTX-DynamoDBFormulaTester-osx\" -ArchiveFileName ".\Artifacts\RJTX-DynamoDBFormulaTester-osx.zip" -Format Zip

