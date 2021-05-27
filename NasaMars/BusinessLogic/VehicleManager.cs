using System;
using System.Collections.Generic;
using System.Text;

namespace NasaMars
{
    /*
        Explanation of design: 

        I divided the solution into 3 projects, a windows forms project for the user interface that only contains actions 
        related to capture user inputs and pass the information to the appropriate manager, a library with the business logic 
        to control the rover and the grid, finally one testing project to test user inputs and rover actions. 

        The business logic project uses some design patterns like singleton used for the grid, I decided to use this pattern 
        since there is only one grid in the input and it is used globally. Another pattern used is strategy, even if there’s 
        no more strategies for now (only Rover), for sure we will have more vehicles in Mars like drones, with strategy pattern 
        developers will be able to add more vehicles without the need of modifying the manager class and other parts of the code. 
        This project also includes some utilities to help with input parse.

        When running the application, the user can use the “Input” field to paste pre-configured information, then the user 
        must click “Parse” button and then “Run” button. If the user does not have pre-configured information, the other input 
        fields can be used to enter data individually and then click “Run” button. 

        Assumptions: 

        - The user is trained to always enter valid inputs. 
        - The user is trained to enter routes where rovers do not collide 
        - The only expected error is when the rover goes out of bounds 
        - The same grid is used for all rovers
    */

    public class VehicleManager
    {
        public static string Execute(List<Tour> tours)
        {
            string result = "";

            // iterates each rover and perform its moves
            foreach (Tour tour in tours)
            {
                foreach (Instruction instruction in tour.Instructions)
                {
                    tour.Vehicle.ExecuteInstruction(instruction);
                    if (tour.Vehicle.Status == State.Unsuccessful)
                    {
                        break;
                    }
                }
                result += tour.Vehicle.ToString() + Environment.NewLine;
            }

            return result;
        }
    }
}
