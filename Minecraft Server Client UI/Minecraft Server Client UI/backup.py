"""
This script was written by Dynatec Computing and is the intellectual property of Dynatec Computing : Mike Fernandez

Description:
        Utilizing Google Drive API for MC World Backups
"""

from __future__ import print_function
import httplib2
import os
import time
from apiclient import discovery
from oauth2client import client
from oauth2client import tools
from oauth2client.file import Storage
from oauth2client.service_account import ServiceAccountCredentials
import xml.dom.minidom


try:
    import argparse
    flags = argparse.ArgumentParser(parents=[tools.argparser]).parse_args()
except ImportError:
    flags = None

#####################################  PREDEFINES  #####################################
########################################################################################
#Scroll down to main() to see what is happening...

#This tells Google what API service you are trying to use (We are using drive)
#If you are backing up to gdrive, don't change this
SCOPES = 'https://www.googleapis.com/auth/drive'

#This points to the JSON key file for the service account
#You should have downloaded the file when creating your service account 
#It should be in the same directory as this script
KEY_FILE_NAME = 'my_project_key_file.json' 

# Directory of file to be copied over to drive
directory = ''

# minutes per save
frequency = 0

# 1 for to Create Folder or 2 to copy existing files, by default if the system detects Write as 
# true in the ini file, existing files from directory will be copied. 
# Only way to create a new folder is to set Write to blank or anything else
input_0 = ' '

# path to ini file, quite self explanatory 
path = 'saveload.ini'

########################################################################################
########################################################################################  
def delete_file(service, file_id):
  """Permanently delete a file, skipping the trash.

  Args:
    service: Drive API service instance.
    file_id: ID of the file to delete.
  """
  try:
    service.files().delete(fileId=file_id).execute()
    return true
  except errors.HttpError as error:
    print('An error occurred: %s') % error
    return false 



def get_service():
    """Get a service that communicates to a Google API.
    Returns:
      A service that is connected to the specified API.
    """
    print("Acquiring credentials...")
    credentials = ServiceAccountCredentials.from_json_keyfile_name(filename=KEY_FILE_NAME, scopes=SCOPES)

    #Has to check the credentials with the Google servers
    print("Authorizing...")
    http = credentials.authorize(httplib2.Http())

    # Build the service object for use with any API
    print("Acquiring service...")
    service = discovery.build(serviceName="drive", version="v3", http=http, credentials=credentials)

    print("Service acquired!")
    return service

def createNewFolder(service,  name):
    """Will create a new folder in the root of the supplied GDrive, 
    doesn't check if a folder with same name already exists.
    Retruns:
        The id of the newly created folder
    """
    folder_metadata = {
        'name' : name,
        'mimeType' : 'application/vnd.google-apps.folder'
    }
    folder = service.files().create(body=folder_metadata, fields='id, name').execute()
    print('Folder Creation Complete')
    folderID = folder.get('id')
    print('Folder Name: %s' % folder.get('name'))
    print('Folder ID: %s \n' % folderID)
    return folderID
def uploadFileToFolder(service, folderID, fileName):
    """Uploads the file to the specified folder id on the said Google Drive
    Returns:
            fileID, A string of the ID from the uploaded file
    """
    file_metadata = None
    if folderID is None:
        file_metadata = {
            'name' : fileName
        }
    else:
        print("Uploading file to: "+folderID)
        file_metadata = {
            'name' : fileName,
            'parents': [ folderID ]
        }

    media = MediaFileUpload(fileName, resumable=True)
    file = service.files().create(body=file_metadata, media_body=media, fields='name,id').execute()
    fileID = file.get('id')
    print('File ID: %s ' % fileID)
    print('File Name: %s \n' % file.get('name'))

    return fileID
def shareFileWithEmail(service, fileID, emailAddress):
    """Shares the specified file via email
    Grants 'writer' privileges by default, which allows
    one to delete the contents of the folder, but not the folder itself
    """
    print("Sharing file with email: "+emailAddress)
    batch = service.new_batch_http_request(callback=callback)
    user_permission = {
        'type': 'user',
        'role': 'writer',
        'emailAddress': emailAddress
    }
    batch.add(service.permissions().create(
        fileId=fileID,
        body=user_permission,
        fields='id',
    ))
    batch.execute()
    print("Sharing complete!\n")
class serializer:
    directory = null
    frequency = null
    gfoldername = null
    delete = null
    def deserialize(path, ):
        file = open(path, r)
        # deserialize contents of xml file and return values
        xml = xml.dom.minidom.parse("saveload.xml");
        # get values and store them 


        return ( directory, frequency, gfoldername, delete)
    def serialize()
   
def main():   
    #getparameters

    directory, frequency, GDRIVE_FOLDER_NAME, delete, uploadFileToFolder, createnewfile, uploadFileToFolder_0 = serializer.deserialize('saveload.xml')
    
    #get the service object using the credentials file
    service = get_service()
    # serialize service
    #Do whatever service object calls here...
    if (createnewfile == true): 
     folderID = createNewFolder(service=service,name=GDRIVE_FOLDER_NAME)
     # serialize folderid 
    if(uploadFileToFolder_0):
     DETACHED_PROCESS = 0x00000008

     pid = subprocess.Popen([sys.executable, "longtask.py"],
                       creationflags=DETACHED_PROCESS).pid
     # serialize xml file with uploadfiletofolder as false
     sys.exit()
    if (delete):
        delete_file(service, folderID)
    #uploads a file to the specified GDrive folder
    # it only uploads file to folder if a frequency is provided, upon so, program restarts in background mode


    
    while uploadFileToFolder:

        start_time = time.time()
        elapsed_time = time.time() - start_time
        if(elapsed_time % iteration == 0):     
          uploadFileToFolder(service=service, folderID=folderID, fileName=FILE_NAME)  
    
    print("Requested operations complete. Exiting...\n")
if __name__ == '__main__':
    main()

