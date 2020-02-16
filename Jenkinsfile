pipeline {
        agent any
        
        environment {
             PATH = "$PATH:/usr/bin"
             Yaml = "grid.yml"
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
              stage ('Docker Swarm init') {
                     steps {
                          sh "docker stack deploy --compose-file $Yaml Grid"
                          sh 'sleep 10'
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
             }
             post {
                     always {
                     echo 'Test Execution complete'
                     sh'docker stack rm Grid'
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
