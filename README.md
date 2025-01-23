<h1 align="center">Devopsifying a Blazor app!!</h1>

- This is a Dotnet Blazor app that has a server section to hold server details. It has a straightforward design and performs only the CRUD functionalities.
- Note: The agenda of this project/usecase is to perform CICD operations at core and not focused on the UI part.

There are 2 sections to this project
1. CI part
2. CD part

## Tools used for CI part: ##
- Github
- Jenkins
- Docker/Docker Hub
- Trivy
- Sonar
- EC2/Local Machine

Check out the following diagram for a visual representation of the CI workflow.

![DEV drawio (1)](https://github.com/user-attachments/assets/4a2b37e3-28ce-400d-b1c2-57c54338b56f)

## CI Part Implementation Steps to install on Local Machine(Ubuntu/Windows using WSL): ##

## 1: Fork and Clone the Project Repository

- **Fork the Repository:**
    
    * Open the repository [Blazor_CRUD_App_Devops](https://github.com/niranjanh123/Blazor_CRUD_App_Devops.git) on GitHub.
        
    * Click **Fork** to create a copy in your GitHub account.
        
- **Clone the Repository:**
    
    * Open the terminal(WSL).
        
    * Clone the repository:
        
        ```bash
        git clone https://github.com/<username>/Blazor_CRUD_App_Devops.git
        ```
        
    * Switch to the feature branch:
        
        ```bash
        git checkout feature
        ```
      
---

## 2. Install WSL if using Windows(Skip for Linux users)

  - Open PowerShell as Administrator:
  Right-click on the Start button and select "Windows PowerShell (Admin)".
  
  - Install WSL:
  In the PowerShell window, type the following command and press Enter:
  wsl --install
  This command will enable the necessary features and install the default Linux distribution, which is Ubuntu.
  
  - Link: https://learn.microsoft.com/en-us/windows/wsl/install

---

## 3. Setting Up Jenkins(CI part)

### Install Jenkins

- Open a Terminal in WSL:
Open your preferred terminal application (e.g., Windows Terminal) and start your WSL instance (e.g., Ubuntu).

- Update Your Package List:
  Run the following commands to update your package list:
  ```bash
  sudo apt update
  sudo apt upgrade
  ```

- Install Java:
  Jenkins requires Java to run. Install OpenJDK with the following command:
  ```bash
      sudo apt install openjdk-11-jdk
  ```

- Add Jenkins Repository:
  Add the Jenkins repository key and source list:
  ```bash
  curl -fsSL https://pkg.jenkins.io/debian-stable/jenkins.io.key | sudo tee /usr/share/keyrings/jenkins-keyring.asc > /dev/null
  echo deb [signed-by=/usr/share/keyrings/jenkins-keyring.asc] https://pkg.jenkins.io/debian-stable binary/ | sudo tee /etc/apt/sources.list.d/jenkins.list > /dev/null
  ```

- Install Jenkins:
  Update your package list again and install Jenkins:
  ```bash
  sudo apt update
  sudo apt install jenkins
  ```

- Start Jenkins:
  Start the Jenkins service:
  ```bash
  sudo service jenkins start
  ```

- Access Jenkins:
  Open a web browser and navigate to http://localhost:8080. You will be prompted to enter an initial admin password, which you can find using:
  ```bash
  sudo cat /var/lib/jenkins/secrets/initialAdminPassword
  ```

- Complete Jenkins Setup:
  Follow the on-screen instructions to complete the setup, including installing recommended plugins and creating your first admin user.
  These steps should get Jenkins up and running on your WSL environment.

- Complete the Jenkins setup by following the on-screen instructions to configure the admin username and password.

---

## 4. Setup Docker and its Permissions

Install **Docker** and add both the current user and the **Jenkins** user to the Docker group:

1. Install Docker:

  ```bash
     sudo apt-get install docker.io
  ```
    
2. Add the current user to the Docker group:
    
    ```bash
    sudo usermod -aG docker $USER && newgrp docker
    ```
    
3. Add the **Jenkins** user to the Docker group:
    
    ```bash
    sudo usermod -aG docker jenkins
    ```
    
4. Restart Jenkins:
    
    ```bash
    sudo systemctl restart jenkins
    ```
    

---

## 5. Setup DockerHub Credentials

- Create a Personal Access Token on DockerHub:
  Log in to your DockerHub account.
  Navigate to Account Settings > Security.
  Click on New Access Token, give it a name, and generate the token. Copy this token as you'll need it later.

- Add Credentials in Jenkins:
  Open your Jenkins dashboard.
  Go to Manage Jenkins > Manage Credentials.
  Select the appropriate domain (e.g., Global).
  Click on Add Credentials on the left-hand side.
  Choose Username with password as the kind.
  Enter your DockerHub username and the personal access token you generated as the password.
  Give it an ID (e.g., dockerhub) and a description, then click OK.

- Use Credentials in Jenkins Pipeline:
  Refer the Jenkinsfile to see the DockerHub Credentials being integrated.

---

## 6. Setup GitHub Credentials

- Generate a Personal Access Token on GitHub:
Log in to your GitHub account.
Go to Settings > Developer settings > Personal access tokens.
Click on Generate new token.
Select the necessary scopes (e.g., repo for full control of private repositories).
Generate the token and copy it for later use.

- Add Credentials in Jenkins:
Open your Jenkins dashboard.
Go to Manage Jenkins > Manage Credentials.
Select the appropriate domain (e.g., Global).
Click on Add Credentials on the left-hand side.
Choose Username with password as the kind.
Enter your GitHub username and the personal access token as the password.
Give it an ID (e.g., github) and a description, then click OK.

- Use Credentials in Jenkins Pipeline:
 Refer the Jenkinsfile to see the Github Credentials being integrated.

## 7. Create a Jenkins Pipeline Job

- Create a New Pipeline Job:
  Open your Jenkins dashboard.
  Click on New Item.
  Enter a name for your pipeline **CICD** and select Pipeline as the project type, then click OK.

- In the pipeline configuration page, scroll down to the Pipeline section.
  Select Pipeline script from SCM if you want to use a Jenkinsfile stored in your source control repository, or Pipeline script to define it directly in Jenkins.

---

## 8\. Build the Pipeline

- You can now click on the Job you created **CICD** and click on **Build Now** option the left side.
- You should be able to see the pipeline running. In case if there are any errors try to fix the issue as part of the learning curve or feel free to reach out to me.
- Issues might be casued due these probable reasons:
  - The Docker Image tag that you have selected is wrong.
  - The Token you have generated might have expired.

---

## The CD part will be updated soon! ##
I'm always open to collaboration! Let's learn and innovate together.

---
## Images of the CI process ##


![CICD Server App](https://github.com/user-attachments/assets/6019babe-ea7c-4dfb-8b0c-da257567ab93)
![CICD Jenkins](https://github.com/user-attachments/assets/e31203dc-a350-4f61-9c8d-533d2af044e9)
![CICD DockerHub](https://github.com/user-attachments/assets/3095371b-0276-4400-a32f-6f0e28f69ae8)
![CICD Jenkins_New](https://github.com/user-attachments/assets/9b417b34-41a7-48eb-9f57-c23a591c0ec7)
![CICD Sonar](https://github.com/user-attachments/assets/fcbbe0e6-b015-4c17-a435-4d85873ebd20)
