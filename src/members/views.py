from django.shortcuts import render, redirect
#from .models import User
from django.contrib.auth.models import User
from .forms import *
from django.contrib.auth import authenticate, login, logout as dlogout

# Create your views here.
def signupView(request):
    context = {}
    return render(request, 'members/signup.html', context)

def loginView(request):
    context = {}
    return render(request, 'members/login.html', context)

def ajaxSignup(request):
    ajax = AjaxSignUp(request.POST)
    context = {'ajax_output': ajax.output()}
    return render(request, 'members/ajax.html', context)

def ajaxLogin(request):
    ajax = AjaxLogin(request.POST)
    logged_in_user, output = ajax.validate()
    if logged_in_user != None:
        login(request, logged_in_user)
    context = {'ajax_output': output}

    return render(request, 'members/ajax.html', context)