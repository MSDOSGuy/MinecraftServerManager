import configparser
parser = configparser.ConfigParser()
parser.add_section('Manager')
parser.set('Manager', 'Name', 'Ashok Kulkarni')
parser.set('Manager', 'email', 'ashok@gmail.com')
parser.set('Manager', 'password', 'secret')
fp=open('test.ini','w')
parser.write(fp)
fp.close()