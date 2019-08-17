pipeline {
    agent any
    parameters {
		string(name: 'GIT_TEST_PATH', defaultValue: 'SampleWebApi.Tests/SampleWebApi.Tests.csproj')
		string(name: 'SOLUTION_FILE_PATH', defaultValue: 'SampleWebApi.sln')
		string(name: 'PROJECT_NAME', defaultValue: 'SampleWebApi')
		string(name: 'DOCKER_USERNAME', defaultValue: 'prakhargupta34')
		string(name: 'DOCKER_PASSWORD')
		string(name: 'DOCKER_REPO_NAME', defaultValue: 'samplewebapi')
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
				
				echo "----------------------------Docker Image Build Started-----------------------------"
				docker build --tag=%DOCKER_USERNAME%/%DOCKER_REPO_NAME% --build-arg project_name=%PROJECT_NAME%.dll .
				echo "----------------------------Docker Image Build Completed-----------------------------"
				'''
			}
			}
				
		stage('Deploy') {
            steps {
                bat '''
				echo "----------------------------Deploying Project Started-----------------------------"
				docker login -u %DOCKER_USERNAME% -p %DOCKER_PASSWORD%
				docker push %DOCKER_USERNAME%/%DOCKER_REPO_NAME%:latest
				echo "----------------------------Deploying Project Completed-----------------------------"
				'''
            }
        }
    }
}
