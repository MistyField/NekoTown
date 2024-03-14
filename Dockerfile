FROM python:3.10
WORKDIR /app
COPY . .
RUN pip install pdm -i https://pypi.tuna.tsinghua.edu.cn/simple
RUN pdm install
EXPOSE 8000
CMD ["pdm", "run", "uvicorn", "app:app", "--host", "0.0.0.0", "--port", "8000"]


