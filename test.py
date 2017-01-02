#<imports>
#import sys
#import numpy
import subprocess, io
import matplotlib.pyplot as pyplot
#</import>

#Path to Windows Forms executable
CSHARP_EXE = r"C:\Users\Alexander Wolff\Documents\Visual Studio 2015\Projects\PythonPlot\PythonPlot\bin\Debug\PythonPlot.exe"

#<main>
print("Python Script Start\n")

#Figure Length in inches (64px per in)
figWidth, figLength = (5, 5)

#Configure Figure {Title, X&Y labels}
pyplot.figure(figsize=(figWidth, figLength))
pyplot.title("Plot Title z")
pyplot.xlabel("x axis")
pyplot.ylabel("y axis")

#Plot data
pyplot.plot(1, 1, 'rx')

#Create Buffer & Save Plot to that buffer
buffer = io.BytesIO()
pyplot.savefig(buffer, dpi='figure', transparent=True, format='png')

#Open pipe to Windows Forms executable & Relays buffer
pipe = subprocess.Popen(CSHARP_EXE, stdout=subprocess.PIPE, stderr=subprocess.PIPE, stdin=subprocess.PIPE)

for std_out in pipe.communicate(buffer.getbuffer()):
    print(std_out)

#</main>
print("Python Script End\n")
