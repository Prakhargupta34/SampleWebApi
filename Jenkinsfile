pipeline {
    agent any
    parameters {
        string(name: 'GIT_HTTPS_PATH', defaultValue: 'https://github.com/tavisca-pgupta/SampleWebApi.git')
		string(name: 'GIT_TEST_PATH', defaultValue: 'SampleWebApi.Tests/SampleWebApi.Tests.csproj')
		string(name: 'SOLUTION_FILE_PATH', defaultValue: 'SampleWebApi.sln')
  }
 
    stages {
        stage('Build') {
            steps {
                powershell '''
                echo "----------------------------Restore Project Started-----------------------------"
				dotnet restore $ENV:WORKSPACE\\$($env:SOLUTION_FILE_PATH) --source https://api.nuget.org/v3/index.json
				echo "----------------------------Restore Project Completed-----------------------------"
				
				echo "----------------------------Build Project Started-----------------------------"
				dotnet build $ENV:WORKSPACE\\$($env:SOLUTION_FILE_PATH) -p:Configuration=release -v:n
				echo "----------------------------Build Project Completed-----------------------------"
				
				echo "----------------------------Test Project Started-----------------------------"
				dotnet test $ENV:WORKSPACE\\$($env:TEST_FILE_PATH)
				echo "----------------------------Test Project Completed-----------------------------"
				'''
			}
			}
				
		stage('Deploy') {
            steps {
                powershell '''
				echo "----------------------------Deploying Project Started-----------------------------"
				dotnet publish -c Release
				dotnet $ENV:WORKSPACE\\SampleWebApi\\bin\\Release\\netcoreapp1.1\\SampleWebApi.dll
				echo "----------------------------Deploying Project Completed-----------------------------"
				'''
            }
        }
    }
	post{
             success{
                 archiveArtifacts artifacts: '**', fingerprint:true
                 bat 'dotnet WebApplication10/bin/Release/netcoreapp2.2/WebApplication10.dll'
             }
        }
}
