"""
#!/usr/bin/env python
# -*- coding:utf-8 -*-
@File : app.py.py
@Author : Zhiyue Chen
@Time : 2024/3/14 23:04
"""
from fastapi import FastAPI

app = FastAPI()

@app.get("/")
async def read_root():
    return {"message": "Hello, backend of NekoTown!"}
