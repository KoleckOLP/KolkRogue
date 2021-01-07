print("Write level name:")
lvlFile = input()

f = open(f"KolkRogue\\{lvlFile}.txt", "r")

lines = f.read().splitlines()

def FindPP():
    for y, line in enumerate(lines):
        for x, char in enumerate(line):
            if(char == "@"):
                return [x, y]

pp = FindPP()

while(True):
    for i, line in enumerate(lines):
        print(line)
        if(i == len(lines)-1):
            print("arrow keys to move around, q - quit to menu")
    
    #Will probaby use py-getch and cry a lot