pipeline {
    agent any
    parameters {
        string(name: 'GIT_HTTPS_PATH', defaultValue: 'https://github.com/tavisca-pgupta/SampleWebApi.git')
		string(name: 'GIT_TEST_PATH', defaultValue: 'SampleWebApi.Tests/SampleWebApi.Tests.csproj')
		string(name: 'SOLUTION_FILE_PATH', defaultValue: 'SampleWebApi.sln')
		string(name: 'NETCORE_VERSION', defaultValue: '')
		choice(name: 'RELEASE_ENVIRONMENT', choices: ['Build', 'Test', 'Both'])
  }
    stages {
        stage('Build') {
			when
            {
                expression { params.RELEASE_ENVIRONMENT == 'Build' || params.RELEASE_ENVIRONMENT == 'Both'}
            }
            steps {
                sh '''
                echo "----------------------------Restore Project Started-----------------------------"
				dotnet${NETCORE_VERSION} restore ${SOLUTION_FILE_PATH} --source https://api.nuget.org/v3/index.json
				echo "----------------------------Restore Project Completed-----------------------------"
				
				echo "----------------------------Build Project Started-----------------------------"
				dotnet${NETCORE_VERSION} build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
				echo "----------------------------Build Project Completed-----------------------------"
				'''
			}
			}
				
		stage('Test') {
			when
            {
                expression { params.RELEASE_ENVIRONMENT == 'Test' || params.RELEASE_ENVIRONMENT == 'Both'}
            }
            steps {
                sh '''
				echo "----------------------------Build Project Started-----------------------------"
				dotnet${NETCORE_VERSION} build ${SOLUTION_FILE_PATH} -p:Configuration=release -v:n
				echo "----------------------------Build Project Completed-----------------------------"
				
                echo "----------------------------Test Project Started-----------------------------"
				dotnet${NETCORE_VERSION} test ${TEST_FILE_PATH}
				echo "----------------------------Test Project Completed-----------------------------"
				'''
            }
        }
    }

	post { 
        always { 
            cleanWs()
        }
    }
}
