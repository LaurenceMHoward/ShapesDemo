# Shapes Demo
This application is a console application that runs on IHost, with DI, and using interfaces for each of the dependencies.
Each class has a single responsability, and because of the singleton pattern, the counter class is accessed in different points. 
The shapes are arranged according to requirements.
1. Generating shapes: quadrilaterals, circles or triangles.  Per requirement.
2. Sorting a collection of shapes by two parameters, and by increasing or decreasing order.
3. Exporting the shape collection to an xml file, through serialization.
4. In-memory tracking of the counts of each of the classes.
5.  SOLID principles were followed using:
    A. Factory Patterns
    B. Builders
    C. Singleton Strategy
    D. Decorators
    E. Facade
    F. Command principles
    with Single Responsabilities
         Open/Closed Architecture
         Liskov Substitution if appropriate.
         Interface seggregation
         Dependency Inversion
    The application is designed with a 3-tier structure: data, process, and application


This program was written in C#. version 7.

# Unit Tests
    Unit Tests were tested for creating the defined requirements of circles, quadrilaterals and triangles.
    Additionally, unit tests were created for testing of the sorting, generation of shapes, 
    and validating that the counting mechanism works as defined.
    1. Additional unit testing should be performed, through the Program Host, to test that the process runs as expected.
    2. Additional testing should be performed to test the export of the xml file, but the tests that exist 
    demonstrate the principles of unit testing.

    Xunit was used, throughout the tests, along with FluentAssertions

