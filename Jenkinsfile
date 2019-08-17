pipeline {
    agent any
    parameters {
		string(name: 'GIT_TEST_PATH', defaultValue: 'SampleWebApi.Tests/SampleWebApi.Tests.csproj')
		string(name: 'SOLUTION_FILE_PATH', defaultValue: 'SampleWebApi.sln')
		string(name: 'PROJECT_NAME', defaultValue: 'SampleWebApi')
		string(name: 'PORT_NO', defaultValue: '5064')
  }
 
    stages {
        stage('Build') {
            steps {
                bat '''
               
				echo "----------------------------Build Project Started-----------------------------"
				dotnet build %SOLUTION_FILE_PATH% -p:Configuration=release -v:n
				echo "----------------------------Build Project Completed-----------------------------"
				
				echo "----------------------------Test Project Started-----------------------------"
				dotnet test %TEST_FILE_PATH%
				echo "----------------------------Test Project Completed-----------------------------"
				
				echo "----------------------------Publishing Project Started-----------------------------"
				dotnet publish %SOLUTION_PATH% -c Release -o ../publish
				echo "----------------------------Publishing Project Completed-----------------------------"
				
				echo "----------------------------Docker Image Started-----------------------------"
				docker build --tag=pipe --build-arg project_name=%PROJECT_NAME%.dll .
				echo "----------------------------Docker Image Completed-----------------------------"
				'''
			}
			}
				
		stage('Deploy') {
            steps {
                bat '''
				echo "----------------------------Deploying Project Started-----------------------------"
				docker run -p %PORT_NO%:80 pipe
				echo "Listening on %PORT_NO%"
				echo "----------------------------Deploying Project Completed-----------------------------"
				'''
            }
        }
    }
}
