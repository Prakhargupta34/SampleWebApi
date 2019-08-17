FROM mcr.microsoft.com/dotnet/core/aspnet

ARG project_name

WORKDIR /app

COPY /publish/. /app

EXPOSE 80

ENV env_project_name=$project_name

CMD ["sh","-c","dotnet ${env_project_name}"]