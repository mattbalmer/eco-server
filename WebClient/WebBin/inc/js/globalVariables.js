;(function () {
    let Variables = function () {
        this.username = localStorage.getItem("username");
        this.authtoken = localStorage.getItem("authtoken");
        this.Info = [];
        // this.SavedDiscussions = [];
        // this.runningElections = [];
        this.previousElections = [];
        this.currentElections = [];
        this.Laws = [];
//        this.iselectionrunning = true;

        this.ignoretownhall = false;
        this.Speech = '';
        this.timerange = [];

        this.activityElections = false;
        this.Playstyles = false;
        this.Events = false;

        this.admin = false;
    };

    Variables.prototype.showError = function (errorResponse) {
        let message = errorResponse.responseJSON && errorResponse.responseJSON.Message || errorResponse.responseText || errorResponse.statusText || errorResponse;
        console.log(errorResponse, message);
        $('.error').empty().html("Error: " + message).fadeIn();
    };

    Variables.prototype.isAdmin = function () {
        let _this = this,
            data = new Object();

        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/isadmin?authtoken=" + _this.authtoken,
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                _this.admin = obj.data;

                if (currentPage == 'laws' && _this.admin) {
                    $('.section-law-info .cancel-law').remove();
                    $('.section-law-info').append("<button class='cancel-law global-button global-button-small' data-hide='no'>Delete Proposal</button>");
                }

                if (_this.admin) {
                    $('#menu-admin').show();
                }
            })
            .catch(function (err) {
                variables.showError(err);
            });
    };

    Variables.prototype.getInfo = function () {
        let data = new Object();
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/info",
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (obj.data) {
                        obj.this.Info = obj.data;
                    }
                    return resolve(obj);
                })
            })
            .then(this.showServer)
            .then(this.Dashboard)
            .catch(function (err) {
                variables.showError(err);
            });
    };

    Variables.prototype.getLawDistrict = function (lawId, fieldId, func) {
        let _this = this;
        let data = new Object();
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/laws/districts",
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    obj.currentDistricts = obj.data;
                    obj.data = {
                        url: APPIQUERYURL + "/api/v1/laws/law/districts/get?lawId=" + lawId + "&fieldId=" + fieldId,
                        data: {},
                        type: 'GET'
                    };
                    obj.func = func;
                    if (fieldId != undefined) return resolve(obj);
                    return reject(obj);
                });
            })
            .then(this.PromiseAjax, this.setLawDistricts)
            .then(this.setLawDistricts)
            .catch(function (err) {
                variables.showError(err);
            });
    };

    Variables.prototype.setLawDistricts = function (obj) {
        return new Promise(function (resolve, reject) {
            if (ECO.MINIMAP.editView) {
                obj.func(obj);
            } else {
                setTimeout(function () {
                    obj.this.setLawDistricts(obj);
                }, 1000);
            }
        });
    };

    Variables.prototype.LoadProposedDistricts = function (data) {

        ECO.MINIMAP.LoadProposedDistricts(data);
    };

    Variables.prototype.setLayer = function (data) {

        ECO.MINIMAP.setLayer(data);
    };

    Variables.prototype.getDistrict = function (fieldId, func) {
        let _this = this;
        let data = new Object();
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/laws/logicDraft/districts/get?username=" + _this.username + "&authtoken=" + _this.authtoken + "&fieldId=" + fieldId,
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    let value = obj.data;
                    if (obj.data) {
                        func(obj);
                    }
                });
            })
            .catch(function (err) {
                variables.showError(err);
            });
    };

    Variables.prototype.setDistrict = function (func) {
        let _this = this;
        let data = new Object();
        let fieldId = $(".district-controls-wrapper").attr("data-fieldid");

        let array = $(".district-item");
        let districts = {
            "DistrictMetadata": [],
            "DistrictMap": ECO.MINIMAP.GetZone()
        };

        for (let i = 0; i < array.length; i++) {
            let item = array[i];
            let color = $(item).css("background-color").split(")")[0].split("(")[1].split(", ");
            let district = {
                "ID": $(item).attr("data-id"),
                "Name": $(item).find(".district-name-input").val(),
                "R": Math.round(parseFloat(color[0]).toFixed(1)),
                "G": Math.round(parseFloat(color[1]).toFixed(1)),
                "B": Math.round(parseFloat(color[2]).toFixed(1))
            };
            districts.DistrictMetadata.push(district);
        }
        districts = JSON.stringify(districts);

        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/laws/logicDraft/districts/set?username=" + _this.username + "&authtoken=" + _this.authtoken + "&fieldId=" + fieldId,
                data: districts,
                type: 'POST',
                contentType: "text/json"
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (func != undefined) func();
                    return resolve(obj);
                });
            })
            .catch(function (err) {
                variables.showError(err);
            });
    };

    Variables.prototype.showServer = function (obj) {
        return new Promise(function (resolve, reject) {
            let data = obj.this.Info;
            let description_arr = data.Description.split(" "),
                description = "";

            for (i in description_arr) {
                let text = description_arr[i];
                if (text.substring(0, 2) == '<#') {
                    description += text.substring(9, text.length) + " ";
                } else {
                    description += text + " ";
                }
            }

            $('#server-title').html("<div class=\"server-detials-title\">Server:</div> <span>" + description + "</span>");
            return resolve(obj);
        });
    };

    Variables.prototype.Dashboard = function (obj) {
        return new Promise(function (resolve, reject) {
                let data = obj.this.Info;
                let row = data.Version;
                $("#version").append(row);
        });
    };

    /* get Saved Discussions */
    Variables.prototype.getSavedDiscussions = function () {
        let data = new Object();
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/analysis/discussions",
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (obj.data) {
                        obj.this.SavedDiscussions = {};
                    }
                    return resolve(obj);
                });
            })
            .then(this.SavedDiscussionsMenu)
            .catch(function (err) {
                variables.showError(err);
            });
    };

    /* menu Saved Discussions */
    Variables.prototype.SavedDiscussionsMenu = function (obj) {
        let data = obj.this.SavedDiscussions;
        if (currentPage == "discussions") {
            SavedDiscussions(data);
        }
    };

    /*canaddcandidate*/
    Variables.prototype.canaddcandidate = function () {
        let _this = this;

        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/elections/canaddcandidate?authtoken=" + _this.authtoken,
                data: {},
                type: 'POST'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {

                $('#add-self').trigger('click');

            })
            .catch(function (err) {
                _this.showError(err);
                variables.showError(err);
            });
    };

    /* get Current Elections */
    Variables.prototype.getCurrentElections = function (obj) {
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/elections",
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (obj.data) {
                        obj.this.currentElections = obj.data;
                    }
                    return resolve(obj);
                })
            })
            .then(this.RunForOffice)
            // .then(function(obj){
            // 	return new Promise(function(resolve,reject){
            // 		let data = {
            // 			url : APPIQUERYURL + "/api/v1/elections/iselectionrunning",
            // 			data : {},
            // 			type : 'GET'
            // 		};
            // 		obj.data = data;
            //
            // 		return resolve(obj);
            // 	});
            // }).then(this.PromiseAjax)
            // .then(function(obj){
            // 	return new Promise(function(resolve,reject){
            // 		if(obj.data){
            // 			obj.this.iselectionrunning = obj.data;
            // 		}else{
            // 			$(".menu-current-elections").html("No Current Election").addClass('menu-no-link').removeAttr("href");
            // 		}
            // 		return resolve(obj);
            // 	})
            // })
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    let data = {
                        url: APPIQUERYURL + "/api/v1/elections/townhallconstructed",
                        data: {},
                        type: 'GET'
                    };
                    obj.data = data;

                    return resolve(obj);
                });
            }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (obj.data) {
                        obj.this.ignoretownhall = obj.data;
                    } else {
                        $(".menu-current-elections").html("No Current Election").addClass('menu-no-link').removeAttr("href");
                    }

                    return resolve(obj);
                })
            })
            .catch(function (err) {
                variables.showError(err);
            });
    };

    /* menu Previous Elections */
    Variables.prototype.RunForOffice = function (obj) {
        let data = obj.this.currentElections;
        return new Promise(function (resolve, reject) {
            if (data && typeof data['Candidates'] != undefined) {
                let candidates = data['Candidates'];

                for (i in candidates) {
                    if (candidates[i].CandidateName == obj.this.username) {
                        RunForOfficeMenu();

                        if (typeof candidates[i].Speech != typeof undefined) {
                            obj.this.Speech = obj.this.decode(candidates[i].Speech);
                        }
                    }
                }
            }
            return resolve(obj);
        });
    };

    Variables.prototype.addSelfCandidate = function (obj) {
        let Speech = variables.Speech;
        $('.error').empty().fadeOut();

        let content = $('.fancy-add-speech');
        content.find('#speech').val(Speech);

        $('#addSpeach').modal('toggle');
    };

    /*adding a speech into election*/
    Variables.prototype.addSpeech = function (obj) {
        let speech = encodeURIComponent($('#speech').val());

        if (speech == "") {
            $('#addSpeach').modal('toggle');
            variables.showError("Speech cannot be empty");
            return false;
        }
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/elections/addcandidate?authtoken=" + variables.authtoken + "&speech=" + speech + "&username=" + variables.username,
                data: {},
                type: 'POST'
            },
            this: this
        })
            .then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {

                    location.href = '/elections.html?election=current';
                })
            })
            .catch(function (err) {
                $('#addSpeach').modal('toggle');
                _this.showError(err);
                variables.showError(err);
            });

    };
    /* get Previous Elections */
    Variables.prototype.showPreviousElections = function(obj){
        let _this = this;
    	Promise.resolve({
    		data : {
    			url : APPIQUERYURL + "/api/v1/elections?authtoken=" + _this.authtoken,
    			data : {returnActive:false},
    			type : 'GET'
    		},
    		this : this
    	}).then(this.PromiseAjax)
    	.then(function(obj){
    		return new Promise(function(resolve,reject){
    			if(obj.data){
    				obj.this.previousElections = obj.data;
    			}
    			return resolve(obj);
    		})
    	})
    	.then(this.PreviousElectionsMenu)
    	.catch(function(err){
    		variables.showError(err);
    	});
    }

    /* get Previous Elections */
    Variables.prototype.showRunningElections = function () {
        let _this = this;
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/elections?authtoken=" + _this.authtoken,
                data: {returnActive: true},
                type: 'GET',
                dataType: 'Json',
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (obj.data) {
                        obj.this.runningElections = obj.data;
                    }
                    return resolve(obj);
                })
            })
            .then(this.RunningElectionsMenu)
            .catch(function (err) {
                variables.showError(err);
            });
    };

    /* menu Running Elections */
    Variables.prototype.RunningElectionsMenu = function (obj) {
        // Clearing elections array from XSS attacks
        let data = clearFromXSS(obj.this.runningElections);

        setTimeout(function () {
            RunningElectionsMenu(data);
        }, 100);
    };

    /* menu Titles */
    Variables.prototype.TitlesMenu = function (titles) {
        //delay to guarantee that menu.js is loaded (which should be refactored as other similar methods)
        setTimeout(function () {
            TitlesMenu(titles);
        }, 100);
    };

    /* get Titles data */
    Variables.prototype.showTitlesMenu = function () {
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/elections/titles",
                type: 'GET',
                dataType: 'Json',
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                if (obj.data) {
                    this.TitlesMenu(obj.data);
                }
            })
            .catch(function (err) {
                variables.showError(err);
            });
    };

    /* menu Previous Elections */
    Variables.prototype.PreviousElectionsMenu = function (obj) {
        // Clearing elections array from XSS attacks
        let data = clearFromXSS(obj.this.previousElections);

        setTimeout(function () {
            PreviousElectionsMenu(data);
        }, 100);
    };

    /*canaddlaw*/
    Variables.prototype.canaddlaw = function () {
        let _this = this;

        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/laws/canaddlaw?authtoken=" + _this.authtoken,
                data: {},
                type: 'GET',
                dataType: 'Json'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (currentPage != 'addlaw') {
                        window.location.href = 'lawsadd.html';
                    }
                })
            })
            .then(this.ActiveProposedLawsMenu)
            .catch(function (err) {

                if (currentPage == 'addlaw') {
                    $('.container-fluid').remove();
                }
                _this.showError(err);
            });
    };

    /* get Laws */
    Variables.prototype.getLaws = function (obj) {
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/laws/byStates/Active|Proposed",
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (obj.data) {
                        obj.this.Laws = obj.data;
                    }
                    return resolve(obj);
                })
            })
            .then(this.ActiveProposedLawsMenu)
            .catch(function (err) {
                variables.showError(err);
            });
    };

    /* menu Active and Proposed Laws*/
    Variables.prototype.ActiveProposedLawsMenu = function (obj) {
        let data = obj.this.Laws;
        setTimeout(function () {
            ActiveProposedLawsMenu(data);
        }, 100);
    };

    Variables.prototype.TimeRange = function (string) {
        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/datasets/timerange",
                data: {},
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                return new Promise(function (resolve, reject) {
                    if (obj.data) {
                        obj.this.timerange = obj.data;
                        if (obj.this.timerange[1] < 0.01) {
                            $('#addGraph,#graph_composer,#graph-populations,.fancy-add-graph').hide();
                            $('#graph_composer').parents('.row1').css('height', 'inherit')
                        }

                        if (currentPage === 'teacher') {
                            eventsControls.bindEvents();
                            playersControls.bindEvents();
                            teacherControls.bindEvents();
                        }
                    }
                    return resolve(obj);
                })
            })
            .catch(function (err) {
                variables.showError(err);
            });
    };

    Variables.prototype.getElectionActivity = function () {
        let _this = this;

        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/elections/activity",
                data: new Array(),
                type: 'GET'
            },
            this: this,
        }).then(this.PromiseAjax)
            .then(function (obj) {
                if (Object.keys(obj.data).length) {
                    _this.activityElections = true;
                }
                _this.citizenActivity();
            }).catch(function (err) {
            variables.showError(err);
        });
    };

    Variables.prototype.getPlaystyles = function () {
        let _this = this,
            data = new Object();

        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/analysis/playstyles",
                data: data,
                type: 'GET'
            },
            this: this,
        }).then(this.PromiseAjax)
            .then(function (obj) {
                if (Object.keys(obj.data).length) {
                    _this.Playstyles = true;
                }
                _this.citizenActivity();
            }).catch(function (err) {
            variables.showError(err);
        });
    };

    Variables.prototype.getEvents = function () {
        let _this = this,
            data = new Object();

        Promise.resolve({
            data: {
                url: APPIQUERYURL + "/api/v1/analysis/discussions/suggest",
                data: data,
                type: 'GET'
            },
            this: this
        }).then(this.PromiseAjax)
            .then(function (obj) {
                if (Object.keys(obj.data).length) {
                    _this.Events = true;
                }
                _this.citizenActivity();
            }).catch(function (err) {
            variables.showError(err);
        });
    };

    Variables.prototype.citizenActivity = function () {
        let _this = this;

        if (!_this.Events) {
            $('.events-table').html('<div class="players-content"><p class="activity-noactivity">No Activity</p></div>');
        }

        if (!_this.activityElections) {
            $('.teacher-row').html('<div class="players-content"><p class="activity-noactivity">No Activity</p></div>');
        }

        if (!_this.Playstyles) {
            $('.players-table').html('<div class="players-content"><p class="activity-noactivity">No Activity</p></div>');
        }

        if (!_this.Events && !_this.activityElections && !_this.Playstyles) {
            if (currentPage == 'teacher') {
                $('.container-fluid .row').hide();
                $('.notification').show();
            }

            //To Do, disable menu link if no content
            $('#citizen-activity a').addClass('menu-no-link');
            $('.menu-teacher a').attr("href", "javascript:;");
            // menu-no-link
        } else {
            if (currentPage == 'teacher') {
                $('.container-fluid .row').show();
                $('.notification').hide();
            }
            $('#citizen-activity a').removeClass('menu-no-link');
            $('.menu-teacher a').attr("href", "activity.html");
        }

    };

    // helper functions start
    Variables.prototype.PromiseAjax = function (obj) {
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: obj.data.url,
                data: obj.data.data,
                type: obj.data.type,
                contentType: obj.data.contentType ? obj.data.contentType : "application/json",
                // dataType: 'json',
                success: function (data) {
                    obj.data = data;
                    return resolve(obj);
                },
                error: function (err) {
                    return reject(err);
                }
            });
        });
    };

    Variables.prototype.bindEvent = function () {
        let _this = this;

        $(document).on('click', '#election-propose-button', function () {

            if (_this.username != null && _this.authtoken != null && _this.ignoretownhall) {
                _this.canaddcandidate();
            } else {
                if (_this.ignoretownhall == false) {
                    _this.showError("The Town Hall hasn't been constructed yet");
                }
                if (_this.username == null || _this.authtoken == null) {
                    _this.showError("You are not logged in. Access website from in game.");
                }
                return false;
            }
        });

        $(document).on("click", '#add-self', function () {
            _this.addSelfCandidate();
        });

        $(document).on('click', '#fancy-speech-save', function () {
            _this.addSpeech();
        });

        $(document).on("click", "#laws-propose-button", function () {
            _this.canaddlaw();
        });

        $(document).on("click", "#login > button", function () {
            $('#loginModal').modal('toggle');
        })
    };

    Variables.prototype.decode = function (string) {
        let encodedStr = string.replace(/[\u00A0-\u9999<>\&]/gim, function (i) {
            return '&#' + i.charCodeAt(0) + ';';
        });
        return encodedStr;
    };

    Variables.prototype.init = function () {
        this.isAdmin();
        this.getInfo();
        // this.getSavedDiscussions();
        //this.getCurrentElections();
        this.showRunningElections();
        this.showPreviousElections();
        this.showTitlesMenu();
          //this.showRunningElections();

        this.getLaws();
        this.TimeRange();
        this.bindEvent();

        if (currentPage == 'teacher') { // this was != teacher for some reason, changed it to avoid calling getPlaystyles on the front page (which is expensive for the server)
            this.getElectionActivity();
            this.getPlaystyles();
            this.getEvents();
        }

    };

    window.variables = new Variables();
    variables.init();

})();