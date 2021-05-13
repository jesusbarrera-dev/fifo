using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

//Round Robin C++ code
/*#pragma warning(disable : 4996)

// Part of OpenGenus IQ
#include<stdio.h>
#include<conio.h>
#include<process.h>
#include<string.h>
void main()
{
    // p -> process
    char p[10][5];
    // et -> execution time for current turn
    // wt -> waiting time
    // pt -> processing time (taken as input)
    int et[10], wt[10], timer = 3, count, pt[10], rt;
    int i, j, totwt = 0, t, n = 5, found = 0, m;
    float avgwt;

    // Read the process name and processing time
    for (i = 0; i < n; i++)
    {
        printf("enter the process name : ");
        scanf("%s", &p[i]);
        printf("enter the processing time : ");
        scanf("%d", &pt[i]);
    }

    m = n;
    wt[0] = 0;
    i = 0;

    // Scheduling starts
    do
    {
        if (pt[i] > timer)
        {
            rt = pt[i] - timer;
            strcpy(p[n], p[i]);
            pt[n] = rt;
            et[i] = timer;
            n++;
        }
        else
        {
            et[i] = pt[i];
        }
        i++;
        wt[i] = wt[i - 1] + et[i - 1];
    } while (i < n);

    count = 0;
    for (i = 0; i < m; i++)
    {
        for (j = i + 1; j <= n; j++)
        {
            if (strcmp(p[i], p[j]) == 0)
            {
                count++;
                found = j;
            }
        }
        if (found != 0)
        {
            wt[i] = wt[found] - (count * timer);
            count = 0;
            found = 0;
        }
    }
    for (i = 0; i < m; i++)
    {
        totwt += wt[i];
    }
    avgwt = (float)totwt / m;

    // Display the Result
    for (i = 0; i < m; i++)
    {
        printf("\nProcess Name\tProcessing Time\tWaiting Time");
        printf("\n\t%s\t\t%d\t\t%d", p[i], pt[i], wt[i]);
    }
    printf("\nTotal waiting time %d\n", totwt);
    printf("Average waiting time %f", avgwt);
}
*/