# A simple makefile for C# projects

# The name of the C# solution file
SRC = assignment2.sln

# The path to the published executable file
OUT = bin/

# The default target
default: build

# The target to build the executable file with AOT compilation
build:
	dotnet publish -c Release $(SRC) -o $(OUT) -r linux-x64

# The target to run the executable file
run: build
	$(OUT)assignment2 positives.txt

# The target to clean the output files
clean:
	dotnet clean