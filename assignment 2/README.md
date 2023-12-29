# Student Names and Numbers
* Martijn Brouwer, s3495485
* Leon Hoogendoorn, s3330931
* Suzanne Wooning, s3197751

# Known Defects
Sometimes the program may not reduce the input expression correctly and will 
return an incorrect result. For example, the input "\x\y(x\z y)" is reduced to
"(\x.(\y.y))" while the original input contains no place where beta-reduction 
can be applied.

# Deviations from the Assignment
We do not have any deviations from the assignment.
