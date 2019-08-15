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
               
				echo "----------------------------Build Project Started-----------------------------"
				dotnet build $($env:SOLUTION_FILE_PATH) -p:Configuration=release -v:n
				echo "----------------------------Build Project Completed-----------------------------"
				
				echo "----------------------------Test Project Started-----------------------------"
				dotnet test $($env:TEST_FILE_PATH)
				echo "----------------------------Test Project Completed-----------------------------"
				
				echo "----------------------------Publishing Project Started-----------------------------"
				dotnet publish $($env:SOLUTION_PATH) -c Release
				echo "----------------------------Publishing Project Completed-----------------------------"
				
				echo "----------------------------Archiving Project Started-----------------------------"
				compress-archive SampleWebApi\\bin\\Release\\netcoreapp1.1\\publish\\* artifact.zip -Update
				echo "----------------------------Archiving Project Completed-----------------------------"
				'''
			}
			}
				
		stage('Deploy') {
            steps {
                powershell '''
				echo "----------------------------Deploying Project Started-----------------------------"
				expand-archive artifact.zip ./ -Force
				dotnet SampleWebApi.dll
				echo "----------------------------Deploying Project Completed-----------------------------"
				'''
            }
        }
    }
}
