import java.util.Scanner;
import static java.lang.System.exit;


public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int choice ,height,width,choiceTriangle,levels,linesInLevel,extra=0,startsInLine,space;
        while (true) {
            System.out.println("press 1 for rectangle , 2 for triangular and 3 to exit");
            choice = scan.nextInt();
            if(choice==3)
                exit(0);
            System.out.println("enter height & width");
            height=scan.nextInt();
            width=scan.nextInt();
            if(choice==1){
                if(Math.abs(height-width)>5)
                    System.out.println("The area of the rectangle is:"+height*width);
                else
                    System.out.println( "The perimeter of the rectangle is:"+height*2+width*2);
            }
            else if(choice==2){
                System.out.println("press 1 for calculating the perimeter of the triangle and 2 for printing the triangle");
                choiceTriangle = scan.nextInt();
                if(choiceTriangle==1)
                    System.out.println("The perimeter of the triangle is:"+(Math.sqrt( Math.pow((double) width/2,2) +Math.pow(height,2)))*2+width);
                else if(choiceTriangle==2){
                    if(width%2==0||height*2<width)
                        System.out.println("The triangle cannot be printed");
                    else {

                        if(width>3){
                        levels=(int)Math.ceil((double)(width-4)/2);
                        linesInLevel=(height-2)/(int)Math.ceil((double)(width-4)/2);
                        startsInLine=3;
                        extra=(height-2)%(int)Math.ceil((double)(width-4)/2);
                        space=width/2-1;
                        }
                        else {
                            levels=1;
                            linesInLevel=height-2;
                            startsInLine=1;
                            space=width/2;
                        }
                        for (int i=1;i<=width/2;i++){
                            System.out.print(" ");
                        }
                        System.out.println("*");
                        for (int i=1;i<=levels;i++){
                            if(i==2)
                                extra=0;
                            for(int j=1;j<=linesInLevel+extra;j++){
                                for(int x=1;x<=space;x++)
                                    System.out.print(" ");
                                for(int k=1;k<=startsInLine;k++)
                                    System.out.print("*");
                                System.out.println();
                            }
                            startsInLine+=2;
                            space-=1;
                        }
                        for (int i=1;i<=width;i++){
                            System.out.print("*");
                        }
                        System.out.println();
                    }
                }
            }
        }

    }
}