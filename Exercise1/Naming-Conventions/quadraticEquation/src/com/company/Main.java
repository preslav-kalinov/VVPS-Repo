package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        double firstParam = scan.nextDouble();
        double secondParam = scan.nextDouble();
        double thirdParam = scan.nextDouble();
        double firstRoot, secondRoot;
        double determinant = secondParam * secondParam - 4 * firstParam * thirdParam;

        if (determinant > 0) {
            firstRoot = (-secondParam + Math.sqrt(determinant)) / (2 * firstParam);
            secondRoot = (-secondParam - Math.sqrt(determinant)) / (2 * firstParam);

            System.out.format("firstRoot = %.2f and root2 = %.2f", firstRoot, secondRoot);
        }
        else if (determinant == 0) {
            firstRoot = secondRoot = -secondParam / (2 * firstParam);
            System.out.format("firstRoot = secondRoot = %.2f;", firstRoot);
        }
        else {
            System.out.println("Determinant is less than 0!!");
        }
    }
}
