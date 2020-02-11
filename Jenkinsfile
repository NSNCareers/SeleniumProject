pipeline {
        agent any
        
        environment {
             PATH = "$PATH:/usr/bin"
                    }
             stages {
                 stage ('Restore Stage') {
                      steps {
                         sh'dotnet restore'
                        }
                    }
             stage ('Clean Stage') {
                     steps {
                         sh'dotnet clean'
                        }
                    }
              stage ('Build Stage') {
                     steps {
                        sh'dotnet build --configuration Release'
                        }
                    }
              stage ('Docker Compose up') {
                     steps {
                          sh "docker-compose build"
                          sh "docker-compose up -d"
                          sh 'sleep 5000'
                            }
                        }
             stage ('Test Stage') {
                     steps {
                          sh'dotnet test'
                            }
                        }
            stage ('Pack Stage') {
                     steps {
                          sh'dotnet pack --no-build --output nupkgs'
                        }
                    }
             post {
                     always {
                     echo 'Test Execution complete'
                     sh'docker-compose down || true'
                      }
                      success {
                      echo 'Job succeeeded!'
                      }
                      unstable {
                      echo 'Job unstable'
                     }
                     failure {
                     echo 'Job failed'
                     }
                     changed {
                     echo 'Things were different before...'
                    }
                     
                 }
            }
