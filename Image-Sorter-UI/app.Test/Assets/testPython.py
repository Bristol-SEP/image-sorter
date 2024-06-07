def noParamTest():
    try:
        print("pass")
        return True
    except:
        return False
    

def paramTest(param1, param2):
    try:
        print(param1)
        print(param2)
        return True
    except:
        return False

def manyParamTest(*arg):
    try:
        print("length: ", len(arg), "arguments: ", arg)
        return True
    except:
        return False