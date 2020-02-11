pipeline {
        agent any
         environment {
             registry = "dockerelvis/employeeapplicationrepo"
             registryCredential = 'dockerhub'
             dockerImagenotage = ''
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
              stage ('Build Image') {
                      steps {
                              sh "docker build -t $registry:$BUILD_NUMBER ."
                              sh "docker build -t $registry ."
                        }
                                         
                    }
               stage ('Deploy Image') {
                     steps {
                          script{
                              withDockerRegistry(credentialsId: '575140d9-14b4-4d0e-8106-6a6509ff19b7', url: 'https://index.docker.io/v1/')
                                  
                                  {     
                               sh "docker push $registry"
                              }
                          }

                        }
                    }
               stage ('Remove unused docker Image') {
                     steps {
                         script{
                              sh "docker rmi $registry:$BUILD_NUMBER"
                          }
                        }
                    }

                 }
            }
