using System;

namespace Petar.IFMO.sem_2.programming.lab_1
    {
    class Book
        {

        public String name;
        public String author;
        public String annotation;
        public String ISBN;
        public String publicationDate;

        public Book(String name, String author, String annotation, String ISBN, String publicationDate)
            {
            this.name = name;
            this.author = author;
            this.annotation = annotation;
            this.ISBN = ISBN;
            this.publicationDate = publicationDate;
            }

        }
    }
