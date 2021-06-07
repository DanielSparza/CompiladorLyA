#include <Servo.h>
#include <Stepper.h>

Servo extendContract, UpDown, OpenClose;
Stepper base(2048, 4, 6, 5, 7);

int x = 0 ;

void setup()
{
extendContract.attach(10);
UpDown.attach(9);
OpenClose.attach(8);
base.setSpeed(5);
}

//RutinaBrazoRobotico
void loop()
{
if (x<3)
{
OpenClose.write(125);
delay(4000);
UpDown.write(180);
delay(4000);
extendContract.write(180);
delay(4000);
base.step(90*5.688888889);
delay(4000);
OpenClose.write(-125);
delay(4000);
UpDown.write(-180);
delay(4000);
extendContract.write(-180);
delay(4000);
OpenClose.write(100);
delay(4000);
UpDown.write(180);
delay(4000);
extendContract.write(180);
delay(4000);
base.step(-90*5.688888889);
delay(4000);
extendContract.write(-90);
delay(4000);
UpDown.write(-90);
delay(4000);
OpenClose.write(-125);
delay(4000);
x++;
}
}

