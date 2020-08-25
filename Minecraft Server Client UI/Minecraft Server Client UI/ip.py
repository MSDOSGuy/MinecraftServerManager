import urllib.request
import socket
import subprocess
import os


def GetINIparam():
    # get external ip
    external_ip = urllib.request.urlopen('api.ipify.org').read().decode('utf8')
    # get hostname
    myHostName = socket.gethostname()
    # get local ip
    localip = socket.gethostbyname(myHostName)
    # return all
    returnvalue = ( external_ip, hostname, localip)
    return returnvalue
def parseinicontents(external_ip, hostname, localip):
    # parse int and store them in variables
    parser = configparser.ConfigParser()    
    parser = configparser.ConfigParser()
    parser.add_section('Properties')
    parser.set('Properties', 'ExternalIP', external_ip)
    parser.set('Properties', 'InternalIP', localip)
    parser.set('Properties', 'Hostname', hostname)
    fp=open('test.ini','w')
    parser.write(fp)
    fp.close()
    
def getstaticip()
    os.system('')
def main():
    print("Getting Parameters...")
    external_ip, hostname, localip, subnet = GetINIparam()
    print("Parsing and Opening upnp.bat...")
    getstaticip()
    parseinicontents(external_ip, hostname, localip)
    subprocess.Popen(["rm","-r","upnp.bat"])



    
