﻿using FluentAssertions;
using PuissanceQuatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuissanceQuatre.Tests
{
    public class PowerStackTests
    {
        [Fact]
        public void Push_IsValidCapacity_ShouldFillTheStack()
        {
            // Arrange
            PowerStack stack = new();
            Token token = new(TokenColor.Red);

            // Act
            bool expected = stack.PushToken(token);

            // Assert
            expected.Should().BeTrue();
        }

        [Fact]
        public void Push_IsNotValidCapacity_ShouldNotFillTheStack()
        {
            // Arrange
            PowerStack stack = new();
            for (int i = 0; i < stack.Capacity; i++)
            {
                Token token = new(TokenColor.Red);
                stack.PushToken(token);
            }

            // Act
            Token newToken = new(TokenColor.Red);
            bool expected = stack.PushToken(newToken);

            // Assert
            expected.Should().BeFalse();
        }

    }
}
