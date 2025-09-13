<h1>IMAGEN POSTGRES EN DOCKER</h1>
docker run -d --name postgres --memory=100m -e POSTGRES_PASSWORD=password123 -e POSTGRES_DB=moneydb -p 5432:5432 -v postgres_data:/var/lib/postgresql/data postgres:13-alpine -c shared_buffers=16MB -c work_mem=1MB -c maintenance_work_mem=8MB -c max_connections=20
