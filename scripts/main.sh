
docker-compose down

docker container stop $(docker ps -a -q)
docker container rm $(docker ps -a -q) 
docker image rmi $(docker images -q)

docker image build . --file dockerfile.api --tag api
docker image build . --file dockerfile.api-dependency --tag api-dependency
docker image build . --file dockerfile.api-service-discovery --tag api-service-discovery

docker-compose up