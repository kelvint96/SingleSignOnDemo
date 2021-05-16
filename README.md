# SingleSignOnDemo
Demo on Single Sign On
![image](https://user-images.githubusercontent.com/82433256/118405539-fec5bf00-b6aa-11eb-80ba-67679ccccecd.png)

## Solutions
| Image  | Port  | Description |
| ----------------------- | ------------ | ------------|
| healthcheckUI  | 9000  | HealthCheck UI to check the healthiness of services |
| IdentityServer  | 8000  | IdentityServer with Microsoft Identity Implementation
| WebClient 1 | 8001| Demo Web Client 1 with Hybrid Grant
| WebClient 2 | 8002| Demo Web Client 2 with Hybrid Grant
| ApiClient 1 | 8003| Demo Api Client 1 as API Resource
| ApiClient 2 | 8004| Demo Api Client 2 as API Resource

## Getting Started

### Prerequisites
|  Name | Download  |
| ------------ | ------------ |
| Git  | https://git-scm.com/downloads  |
| Docker  |  https://www.docker.com/products/docker-desktop |
| .Net 5.0 Runtime | https://dotnet.microsoft.com/download/dotnet/5.0|

Make sure all the prerequisites are installed before proceeding.

### Steps
**Important: Make sure that Docker Desktop is running before proceeding. Please also ensure that no other application are running on the same ports as the application mentioned in the section above.**

1. Firstly, create an empty folder and clone the repository into the folder.

` git clone https://github.com/kelvint96/SingleSignOnDemo`

2. This may take a minute or two. 
3. You may now run the following docker commands to install the images and host the solutions in docker. This might take a minute or two, while docker is pulling the images.

`docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d`

4. After running the above commands, you should be able to see the solution being run on docker desktop.

5. You may now launch the solution from the designated ports listed on the table above:


