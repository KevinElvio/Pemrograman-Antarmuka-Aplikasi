#!/usr/bin/env python
# encoding: utf-8
import json
from flask import Flask
app = Flask(__name__)
@app.route('/')
def index():
    return json.dumps({'name': 'Kevin Elvio',
                       'email': 'kevinelvio18@gmail.com'})
app.run()