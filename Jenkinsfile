pipeline {
     agent any
     
     environment {
        DOCKER_BASE_NAME = "blazorservertodoapp"
        DOCKER_VERSION = "1.0.0"
        SONAR_HOME = tool "SonarQube"
     }
    
    stages{
        stage("Checkout branch SCM"){
            steps{
                echo "Checking out to git branch"
                git url: "https://github.com/niranjanh123/Blazor_CRUD_App_Devops.git",branch :"main"
                echo "Branch checkout successfull!"
            }
        }
        stage('SonarQube Analysis') {
            steps {
                withSonarQubeEnv("SonarQube") {
                    sh "$SONAR_HOME/bin/sonar-scanner -Dsonar.projectName=BlazorappCICD -Dsonar.projectKey=BlazorappCICD"
                }
            }
        }    
        stage("Build the App") {
            steps {
                sh "docker build -t  $DOCKER_BASE_NAME:$DOCKER_VERSION ."
                echo "Docker Build complete!"
            }
        }
        stage('Scan Docker Image using Trivy') {
            steps {
                script {
                    // Run Trivy to scan the Docker image
                    def trivyOutput = sh(script: "trivy image $DOCKER_BASE_NAME:$DOCKER_VERSION", returnStdout: true).trim()

                    // Display Trivy scan results
                    println trivyOutput

                    // Check if vulnerabilities were found
                    if (trivyOutput.contains("Total: 0")) {
                        echo "No vulnerabilities found in the Docker image."
                    } else {
                        echo "Vulnerabilities found in the Docker image."
                        // You can take further actions here based on your requirements
                        // For example, failing the build if vulnerabilities are found
                        // error "Vulnerabilities found in the Docker image."
                    }
                }
            }
        }
        stage("Push image to Docker hub"){
            steps{
                    withCredentials([usernamePassword(credentialsId: 'DockerHubCred', 
                                                     usernameVariable: 'DOCKER_USERNAME', 
                                                     passwordVariable: 'DOCKER_PASSWORD')]) 
                {
                    sh "docker login -u ${env.DOCKER_USERNAME} -p ${env.DOCKER_PASSWORD}"
                    sh "docker image tag $DOCKER_BASE_NAME:$DOCKER_VERSION ${env.DOCKER_USERNAME}/$DOCKER_BASE_NAME:$DOCKER_VERSION"
                    sh "docker push ${env.DOCKER_USERNAME}/$DOCKER_BASE_NAME:$DOCKER_VERSION"
                    echo "The image has been pushed to Docker Hub successfully!"
                }
            }
        }
        stage("Deploy") {
            steps {
                 sh "docker run -d -p 8089:8080 $DOCKER_BASE_NAME:$DOCKER_VERSION"
                //sh "docker compose down"
                //sh "docker compose up -d"
                //echo "App deployed to AWS!"
            }
        }
         stage("Deploy on Minikube") {
            steps {
                 sh "minikube status"
                 echo "Minikube running!!"
            }
        }


        
    }
}
