# A simple makefile for C# projects

# The name of the C# solution file
SRC = assignment1.sln

# The path to the published executable file
OUT = bin/

# The default target
default: build

# The target to build the executable file
build:
	dotnet publish -c Release $(SRC) -o $(OUT)

# The target to run the executable file
run: build
	$(OUT)assignment1 positives.txt

# The target to clean the output files
clean:
	dotnet clean