//-----------------------------------------------------------------------
// <copyright file="ForgeSchemaHelper.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     Helper class for TreeWalkerUnitTests that holds ForgeSchema examples.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.Forge.TreeWalker.UnitTests
{
    public static class ForgeSchemaHelper
    {
        public const string ActionException_Fail = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""ThrowException"": true
                                }
                            }
                        }
                    }
                }
            }";

        public const string ActionException_ContinuationOnRetryExhaustion_And_Skip = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""ThrowException"": true
                                },
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        },
                        ""ChildSelector"":
                        [
                            {
                                ""Label"": ""WhenActionSkip_IsSkipped"",
                                ""ShouldSelect"": ""C#|Session.GetCurrentNodeSkipActionContext() == \""Skipped\"""",
                                ""Child"": ""TestDelayExceptionAction_TreeNode""
                            },
                            {
                                ""Label"": ""WhenActionSkip_IsNotSkipped_ButNotEmpty"",
                                ""ShouldSelect"": ""C#|!string.IsNullOrWhiteSpace(Session.GetCurrentNodeSkipActionContext()) && Session.GetCurrentNodeSkipActionContext() != \""Skipped\"""",
                                ""Child"": ""ReturnSessionIdAction""
                            }
                        ]
                    },
                    ""TestDelayExceptionAction_TreeNode"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""TestDelayExceptionAction_0"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""ThrowException"": false
                                }
                            }
                        }
                    },
                    ""ReturnSessionIdAction"": {
                        ""Type"": ""Action"",
                            ""Actions"": {
                            ""ReturnSessionIdAction_0"": {
                                ""Action"": ""ReturnSessionIdAction""
                            }
                        }
                    }
                }
            }";

        public const string ActionException_ContinuationOnRetryExhaustion = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""ThrowException"": true
                                },
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        }
                    }
                }
            }";

        public const string ActionDelay_Fail = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""DelayMilliseconds"": 50
                                },
                                ""Timeout"": 10,
                            }
                        }
                    }
                }
            }";

        public const string ActionDelay_ContinuationOnTimeout = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""DelayMilliseconds"": 50
                                },
                                ""Timeout"": 10,
                                ""ContinuationOnTimeout"": true
                            }
                        }
                    }
                }
            }";

        public const string ActionDelay_ContinuationOnTimeout_RetryPolicy_TimeoutInAction = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""DelayMilliseconds"": 50,
                                    ""ThrowException"": true
                                },
                                ""Timeout"": 100,
                                ""RetryPolicy"": {
                                    ""Type"": ""FixedInterval"",
                                    ""MinBackoffMs"": 25
                                },
                                ""ContinuationOnTimeout"": true
                            }
                        }
                    }
                }
            }";

        public const string ActionDelay_ContinuationOnTimeout_RetryPolicy_TimeoutBetweenRetries = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""DelayMilliseconds"": 25,
                                    ""ThrowException"": true
                                },
                                ""Timeout"": 50,
                                ""RetryPolicy"": {
                                    ""Type"": ""FixedInterval"",
                                    ""MinBackoffMs"": 100
                                },
                                ""ContinuationOnTimeout"": true
                            }
                        }
                    }
                }
            }";

        public const string ActionDelay_ContinuationOnRetryExhaustion_RetryPolicy_FixedCount = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""ThrowException"": true,
                                    ""DelayMilliseconds"": 10
                                },
                                ""Timeout"": 100,
                                ""RetryPolicy"": {
                                    ""Type"": ""FixedCount"",
                                    ""MinBackoffMs"": 25,
                                    ""MaxRetry"": 2,
                                },
                                ""ContinuationOnTimeout"": true,
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        }
                    }
                }
            }";

        public const string ActionDelay_ContinuationOnTimeout_RetryPolicy_FixedCount = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestDelayExceptionAction"": {
                                ""Action"": ""TestDelayExceptionAction"",
                                ""Input"": {
                                    ""ThrowException"": true,
                                    ""DelayMilliseconds"": 150
                                },
                                ""Timeout"": 100,
                                ""RetryPolicy"": {
                                    ""Type"": ""FixedCount"",
                                    ""MinBackoffMs"": 25,
                                    ""MaxRetryCount"": 2,
                                },
                                ""ContinuationOnTimeout"": true,
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        }
                    }
                }
            }";

        public const string NoChildMatch = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Selection"",
                        ""ChildSelector"": [
                            {
                                ""Label"": ""Label"",
                                ""ShouldSelect"": ""C#|false"",
                                ""Child"": ""LeafNode""
                            }
                        ]
                    },
                    ""LeafNode"": {
                        ""Type"": ""Leaf""
                    }
                }
            }
        ";

        public const string TestEvaluateInputType_FailOnField_Action = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestEvaluateInputType_FailOnField_Action"": {
                                ""Action"": ""TestEvaluateInputType_FailOnField_Action"",
                                ""Input"": {
                                    ""UnexpectedField"": true
                                },
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        }
                    }
                }
            }
        ";

        public const string TestEvaluateInputTypeAction_UnexpectedPropertyFail = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestEvaluateInputTypeAction"": {
                                ""Action"": ""TestEvaluateInputTypeAction"",
                                ""Input"": {
                                    ""UnexpectedProperty"": true
                                },
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        }
                    }
                }
            }
        ";

        public const string TestEvaluateInputType_FailOnNonEmptyCtor_Action = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestEvaluateInputType_FailOnNonEmptyCtor_Action"": {
                                ""Action"": ""TestEvaluateInputType_FailOnNonEmptyCtor_Action"",
                                ""Input"": {
                                    ""BoolProperty"": true
                                },
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        }
                    }
                }
            }
        ";

        public const string TestEvaluateInputTypeAction_UndefinedEnumMemberFail = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_TestEvaluateInputTypeAction"": {
                                ""Action"": ""TestEvaluateInputTypeAction"",
                                ""Input"": {
                                    ""FooEnumArray"": [
                                        ""UNDEFINED_Enum_Value""
                                    ]
                                },
                                ""ContinuationOnRetryExhaustion"": true
                            }
                        }
                    }
                }
            }
        ";

        public const string LeafNodeSummaryAction = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Leaf"",
                        ""Actions"": {
                            ""Root_LeafNodeSummaryAction"": {
                                ""Action"": ""LeafNodeSummaryAction"",
                                ""Input"": {
                                    ""Status"": ""Success"",
                                    ""StatusCode"": 1,
                                    ""Output"": ""TheResult""
                                }
                            }
                        }
                    }
                }
            }
        ";

        public const string ExternalExecutors = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Leaf"",
                        ""Actions"": {
                            ""Root_LeafNodeSummaryAction"": {
                                ""Action"": ""LeafNodeSummaryAction"",
                                ""Input"": {
                                    ""Status"": ""External|StatusResult""
                                }
                            }
                        }
                    }
                }
            }
        ";

        public const string SubroutineAction_NoActions = @"
            {
                ""RootTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Subroutine"",
                            ""Actions"": {
                                ""Root_Subroutine"": {
                                    ""Action"": ""SubroutineAction"",
                                    ""Input"": {
                                        ""TreeName"": ""SubroutineTree"",
                                        ""TreeInput"": ""TestValue""
                                    }
                                }
                            }
                        }
                    }
                },
                ""SubroutineTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Leaf""
                        }
                    }
                }
            }
        ";

        public const string SubroutineAction_ParallelSubroutineActions = @"
            {
                ""RootTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Subroutine"",
                            ""Actions"": {
                                ""Root_Subroutine_One"": {
                                    ""Action"": ""SubroutineAction"",
                                    ""Input"": {
                                        ""TreeName"": ""SubroutineTree"",
                                        ""TreeInput"": ""TestValueOne""
                                    }
                                },
                                ""Root_Subroutine_Two"": {
                                    ""Action"": ""SubroutineAction"",
                                    ""Input"": {
                                        ""TreeName"": ""SubroutineTree"",
                                        ""TreeInput"": ""TestValueTwo""
                                    }
                                },
                                ""Root_CollectDiagnosticsAction"": {
                                    ""Action"": ""CollectDiagnosticsAction"",
                                    ""Input"": {
                                        ""Command"": ""TheCommand""
                                    }
                                }
                            }
                        }
                    }
                },
                ""SubroutineTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Leaf"",
                            ""Actions"": {
                                ""Root_LeafNodeSummaryAction"": {
                                    ""Action"": ""LeafNodeSummaryAction"",
                                    ""Input"": {
                                        ""Status"": ""C#|(string)TreeInput"",
                                    }
                                }
                            }
                        }
                    }
                }
            }
        ";

        public const string SubroutineAction_FailsOnActionTreeNodeType = @"
            {
                ""RootTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Action"",
                            ""Actions"": {
                                ""Root_Subroutine"": {
                                    ""Action"": ""SubroutineAction"",
                                    ""Input"": {
                                        ""TreeName"": ""SubroutineTree"",
                                        ""TreeInput"": ""TestValue""
                                    }
                                }
                            }
                        }
                    }
                },
                ""SubroutineTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Leaf""
                        }
                    }
                }
            }
        ";

        public const string SubroutineAction_FailsOnNoSubroutineAction = @"
            {
                ""RootTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Subroutine""
                        }
                    }
                }
            }
        ";

        public const string CycleSchema = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_RevisitAction"": {
                                ""Action"": ""RevisitAction""
                            }
                        },
                        ""ChildSelector"": [
                            {
                                ""Label"": ""Label"",
                                ""ShouldSelect"": ""C#|(int)Session.GetLastActionResponse().Output < 3"",
                                ""Child"": ""Root""
                            }
                        ]
                    }
                }
            }
        ";

        public const string ReExecuteNodeSchema = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_RevisitAction"": {
                                ""Action"": ""RevisitAction""
                            }
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|(int)Session.GetLastActionResponse().Output > 2"",
                                ""Child"": ""Root""
                            }
                        ]
                    }
                }
            }
        ";

        public const string Cycle_SubroutineActionUsesDifferentSessionId = @"
            {
                ""RootTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Subroutine"",
                            ""Actions"": {
                                ""Root_Subroutine"": {
                                    ""Action"": ""SubroutineAction"",
                                    ""Input"": {
                                        ""TreeName"": ""SubroutineTree""
                                    }
                                },
                                ""Root_RevisitAction"": {
                                    ""Action"": ""RevisitAction""
                                }
                            },
                            ""ChildSelector"": [
                                {
                                    ""Label"": ""Label"",
                                    ""ShouldSelect"": ""C#|(int)Session.GetOutput(\""Root_RevisitAction\"").Output < 3"",
                                    ""Child"": ""Root""
                                }
                            ]
                        }
                    }
                },
                ""SubroutineTree"": {
                    ""Tree"": {
                        ""Root"": {
                            ""Type"": ""Action"",
                                ""Actions"": {
                                ""Root_ReturnSessionIdAction"": {
                                    ""Action"": ""ReturnSessionIdAction""
                                }
                            }
                        }
                    }
                }
            }
        ";

        #region CacheVariables Schemas

        /// <summary>
        /// Basic CacheVariables test — static Roslyn expression evaluated after action, used in ShouldSelect.
        /// </summary>
        public const string CacheVariables_StaticExpression = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""myVal"": ""C#|42""
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|(int)Cache.myVal == 42"",
                                ""Child"": ""CorrectValue""
                            },
                            {
                                ""Child"": ""WrongValue""
                            }
                        ]
                    },
                    ""CorrectValue"": {
                        ""Type"": ""Leaf""
                    },
                    ""WrongValue"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        /// <summary>
        /// CacheVariables referencing Session.GetOutput to extract ActionResponse data.
        /// </summary>
        public const string CacheVariables_SessionGetOutput = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""actionStatus"": ""C#|Session.GetOutput(\""Root_CollectDiagnosticsAction\"").Status""
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|Cache.actionStatus == \""Success\"""",
                                ""Child"": ""Found""
                            },
                            {
                                ""Child"": ""NotFound""
                            }
                        ]
                    },
                    ""Found"": {
                        ""Type"": ""Leaf""
                    },
                    ""NotFound"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        /// <summary>
        /// CacheVariables using UserContext.
        /// </summary>
        public const string CacheVariables_UserContext = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""userName"": ""C#|UserContext.Name""
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|Cache.userName == \""MyName\"""",
                                ""Child"": ""Found""
                            },
                            {
                                ""Child"": ""NotFound""
                            }
                        ]
                    },
                    ""Found"": {
                        ""Type"": ""Leaf""
                    },
                    ""NotFound"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        /// <summary>
        /// CacheVariables are node-scoped — second node should NOT see first node's cache variables.
        /// </summary>
        public const string CacheVariables_NodeScoped = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""firstNodeVar"": ""C#|99""
                        },
                        ""ChildSelector"": [
                            {
                                ""Child"": ""SecondNode""
                            }
                        ]
                    },
                    ""SecondNode"": {
                        ""Type"": ""Selection"",
                        ""CacheVariables"": {
                            ""secondNodeCheck"": ""C#|Session.GetCache(\""firstNodeVar\"") == null ? \""isolated\"" : \""leaked\""""
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|Cache.secondNodeCheck == \""isolated\"""",
                                ""Child"": ""Isolated""
                            },
                            {
                                ""Child"": ""Leaked""
                            }
                        ]
                    },
                    ""Isolated"": {
                        ""Type"": ""Leaf""
                    },
                    ""Leaked"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        /// <summary>
        /// CacheVariables with invalid expression — should throw CacheVariableException.
        /// </summary>
        public const string CacheVariables_InvalidExpression = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""badVar"": ""C#|NonExistentObject.Property""
                        },
                        ""ChildSelector"": [
                            {
                                ""Child"": ""End""
                            }
                        ]
                    },
                    ""End"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        /// <summary>
        /// Multiple CacheVariables on the same node.
        /// </summary>
        public const string CacheVariables_Multiple = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""a"": ""C#|10"",
                            ""b"": ""C#|20"",
                            ""sum"": ""C#|30""
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|(int)Cache.a + (int)Cache.b == (int)Cache.sum"",
                                ""Child"": ""Found""
                            },
                            {
                                ""Child"": ""NotFound""
                            }
                        ]
                    },
                    ""Found"": {
                        ""Type"": ""Leaf""
                    },
                    ""NotFound"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        /// <summary>
        /// CacheVariables with string literal (non-Roslyn value).
        /// </summary>
        public const string CacheVariables_StringLiteral = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""literal"": ""hello world""
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|Cache.literal.ToString() == \""hello world\"""",
                                ""Child"": ""Found""
                            },
                            {
                                ""Child"": ""NotFound""
                            }
                        ]
                    },
                    ""Found"": {
                        ""Type"": ""Leaf""
                    },
                    ""NotFound"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        /// <summary>
        /// Schema for testing GetCache API.
        /// </summary>
        public const string CacheVariables_GetCacheApi = @"
            {
                ""Tree"": {
                    ""Root"": {
                        ""Type"": ""Action"",
                        ""Actions"": {
                            ""Root_CollectDiagnosticsAction"": {
                                ""Action"": ""CollectDiagnosticsAction"",
                                ""Input"": {
                                    ""Command"": ""TheCommand""
                                }
                            }
                        },
                        ""CacheVariables"": {
                            ""testVal"": ""C#|\""cached_value\""""
                        },
                        ""ChildSelector"": [
                            {
                                ""ShouldSelect"": ""C#|Session.GetCache(\""testVal\"").ToString() == \""cached_value\"""",
                                ""Child"": ""Found""
                            },
                            {
                                ""Child"": ""NotFound""
                            }
                        ]
                    },
                    ""Found"": {
                        ""Type"": ""Leaf""
                    },
                    ""NotFound"": {
                        ""Type"": ""Leaf""
                    }
                }
            }";

        #endregion CacheVariables Schemas
    }
}