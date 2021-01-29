(function () {
    let Election = function () {

        /* @type string - introducses username value in the url */
        this.username = localStorage.getItem("username");

        /* @type string - introduces the authtoken value in the url */
        this.authtoken = localStorage.getItem("authtoken");

        /* @type bool - shows if there's an election running */
        this.runningElection = false;

        /* @type string - url parameter for disabling Town Hall blocking mode */
        this.ignoretownhall = getURLParameter('ignoretownhall');

        /* @type object - settings for elections pages */
        this.settings = {
            availableCommentPages: ['current']
        };

        /* @type object or array - election data from ajax request */
        this.electionData = [];

        /* @type object or array - election data from ajax request */
        this.currentElectionData = {};

        /* @type object or array - vote data from ajax request */
        this.voteData = [];

        /* @type object or array - info data from ajax request */
        this.infoData = [];

        this.election = this;

        /* METHODS */

        /**
         * showing Error messages
         */
        this.showError = function (message, type) {
            if (typeof type === "undefined") {
                variables.showError(message);
            } else if (type === "success") {
                $('.error').empty().html(message).fadeIn();
            }
        };

        this.showElectionProcess = function (electionId) {
            let _that = this;

            let showElectionProcess = function (data) {
                let electionTableData = data.ElectionProcess;
                let electionProcessInfoTemplate = $.templates("#election-process-table-template");
                let html = electionProcessInfoTemplate.render(electionTableData);

                $("#election-process-modal-table-placeholder").html(html);

                $('#election-process-modal-table-placeholder .flat-table .table-middle:odd').addClass("table-alternating-color-1");
                $('#election-process-modal-table-placeholder .flat-table .table-middle:even').addClass("table-alternating-color-2");

                //
                $('#election-process-modal').modal('toggle');
                //$(".fancy-election-title-contents").fadeIn();
            };

            _that.getElectionById(electionId, showElectionProcess, false);
        };


        this.showElectionActionOnCompleteTable = function (electionId) {
            let _that = this;

            let showElectionActionOnCompleteTable = function (data) {
                let electionTableData = data;
                let electionProcessInfoTemplate = $.templates("#election-action-on-complete-table-template");
                let html = electionProcessInfoTemplate.render(electionTableData);

                $("#election-action-on-complete-table-wrapper").html(html);
                $("#election-action-on-complete-table-wrapper").show();

                $('#election-action-on-complete-table-wrapper .flat-table .table-middle:odd').addClass("table-alternating-color-1");
                $('#election-action-on-complete-table-wrapper .flat-table .table-middle:even').addClass("table-alternating-color-2");
            };

            _that.getElectionById(electionId, showElectionActionOnCompleteTable, false);
        };

        this.showElectionProcessLink = function (data) {

            let electionProcessInfoTemplate = $.templates("#election-process-link-template");
            let html = electionProcessInfoTemplate.render(data.ElectionProcess);

            html += "<li><span class='view-all-votes localize' translate-key='36'>View All Votes</span></li>";
            $("#election-info-results-wrapper").append(html);


        };

        this.showElectionName = function (data) {

            let electionNameTemplate = $.templates("#election-name-template");
            let html = electionNameTemplate.render(data);

            $("#election-name-wrapper").html(html);
            $("#election-name-wrapper").show();
        };

        /**
         * get all election by type(previous,current)
         */
        this.getElectionById = function (id, callback, update) {
            update = update || false;

            let url = APPIQUERYURL + "/api/v1/elections/" + id;
            let that = this;

            if (Object.keys(that.electionData).length && !update) {
                return callback(that.electionData);
            }

            return $.ajax({
                url: url,
                type: "get",
                async: false,
                success: function (data) {
                    for (let i = 0; i < data.Results.ChoiceRanks.length; i++) {
                        let item = data.Results.ChoiceRanks[i];
                        if (item.VotesPerRound === undefined) {
                            item.VotesPerRound = [];
                        }
                        data.Results.ChoiceRanks[i] = item;
                    }

                    // saving election data, because not to do ajax second time and clearing from XSS attacks
                    that.electionData = clearFromXSS(data);
                    if (data.Comments.length == 0) {
                        $('#graph_composer').remove();
                    }
                    if (data.Comments) {
                        callback(that.electionData);
                    }
                }
            });
        };

        // /**
        //  * get current election
        //  */
        // this.getCurrentElection = function (callback, update) {
        //     update = update || false;
        //     let url = APPIQUERYURL + "/api/v1/elections/current",
        //         _this = this;
        //
        //     if (Object.keys(_this.currentElectionData).length && !update) {
        //         callback(_this.currentElectionData);
        //     } else {
        //         $.ajax({
        //             url: url,
        //             type: "get",
        //             async: false,
        //             success: function (data) {
        //                 // saving election data, because not to do ajax second time
        //                 _this.currentElectionData = data;
        //                 callback(data);
        //             }
        //         })
        //     }
        // };

        /**
         * get all vote by guid
         */
        this.getVote = function (guid, callback, update) {
            update = update || false;
            let url = APPIQUERYURL + "/api/v1/elections/votes?authtoken=" + election.authtoken + ((typeof guid !== typeof undefined) ? "&Id=" + guid : "");
            _this = this;
            if (Object.keys(_this.voteData).length && !update) {
                callback(_this.voteData);
            } else {
                $.ajax({
                    url: url,
                    type: "get",
                    async: false,
                    success: function (data) {
                        // saving vote data, because not to do ajax second time
                        _this.voteData = data;
                        callback(data);
                    }
                })
            }
        };

        /**
         * get info
         */
        this.getInfo = function (callback, update) {
            let url = APPIQUERYURL + "/info",
                _this = this;

            if (Object.keys(_this.infoData).length && !update) {
                callback(_this.infoData);
            } else {
                $.ajax({
                    url: url,
                    type: "get",
                    async: false,
                    success: function (data) {
                        // saving info data, because not to do ajax second time
                        _this.infoData = data;
                        callback(data);
                    }
                })
            }
        };

        // this.getElectionComments = function (electionId) {
        //     let url = APPIQUERYURL + "/api/v1/elections/listcomments?electionId=" + electionId;
        //     return $.ajax({
        //         url: url,
        //         type: "get",
        //         dataType: "Json"
        //     })
        // };

        /**
         * get all comments
         */
        this.getAllComments = function(guid, update = false) {
            if (currentPage != 'elections') return false;

            this.getElectionById(guid, updateComment, update);

            if (ECO.MINIMAP.initialized) {
                ECO.MINIMAP.removeDeadViews();
            }

            function updateComment(data) {

                $('.election-discussion .discussion-user').empty();

                // if (data instanceof Array) data = data[0];

                let cycleLength = data.Comments.length;

                for (let i = 0; i < cycleLength; i++) {
                    let comment;
                    let isEdited;

                    data.Comments[i].Text = data.Comments[i].Text.trim()
                        .replace(/\\{1,2}n/g, "<br>").replace(/\\"/g, '&quot').replace(/^["]|"$|\\/g, "");

                    let matchJson  = /^[\],:{}\s]*$/.test(data.Comments[i].Text.replace(/\\["\\\/bfnrtu]/g, '@').replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']').replace(/(?:^|:|,)(?:\s*\[)+/g, ''));
                    let onlyDigits = /^\d+$/.test(data.Comments[i].Text);

                    //checking if return text is valid json text
                    if (matchJson && !onlyDigits) {
                        try {
                            comment = data.Comments[i].Text.length ? JSON.parse(data.Comments[i].Text) + '' : '';
                        } catch (e) {
                            comment = data.Comments[i].Text+'';
                        }
                        // Editing feature to do
                        //isEdited = JSON.parse(data.Comments[i].IsEdited);
                    } else {
                        comment = data.Comments[i].Text+'';
                        // Editing feature to do
                        //isEdited = data.Comments[i].IsEdited;
                    }

                    while (comment.indexOf("\n") >= 0) {
                        comment = comment.replace("\n", "<br>");
                    }

                    // getting days, hours and minutes from timestamp value of query
                    let timestamp   = data.Comments[i].Timestamp;
                    let commentTime = "Posted on  " + ConvertSecondsComments(timestamp);
                    let text        = $("<div class='law-discussion-wrapper'></div>");
                    let section1    = $("<div class='comment-section1'> </div>");

                    // Editing and removing comments on hold:

                    // checking if a user can remove comment
                    // let removeComment = '';
                    // let editComment   = '';
                    // let hasGraph      = data.Comments[i].Graph && data.Comments[i].Graph.Keys != '';

                    //including removeGraph and editgraph buttons
                    // if (data.Comments[i].Username == election.Creator) {
                    //     removeComment = "<a data-graph='" + hasGraph + "' id='removeComment' href='javascript:void(0)'><i class='fa fa-times'></i> remove </a>";
                    //
                    //     let graphs = "";
                    //
                    //     if (hasGraph) {
                    //         graphs = JSON.stringify({
                    //             categories: data.Comments[i].Graph.Keys,
                    //             time_start: data.Comments[i].Graph.TimeMin,
                    //             time_end:   data.Comments[i].Graph.TimeMax
                    //         });
                    //     }
                    //
                    //     editComment = "<a data-graph='" + graphs + "' id='editComment' href='javascript:void(0)'><i class='fa fa-edit'></i> edit </a>";
                    // }

                    section1.append("<div class='law-discussion-user'>" + data.Comments[i].Username + "<span class='law-discussion-time'>" + commentTime + (isEdited ? "<i style='font-size:13px;'>&nbsp;(edited)</i>" : "") + "</span></div><div class='law-discussion-comment'>" + comment + "</div>");
                    text.append(section1);

                    let view = null;

                    if (data.Comments[i].Map != null && data.Comments[i].Map != "") {
                        let viewer = $(`</div><div class="view-map" id="map-${i}"></div>`);
                        section1.after(viewer);

                        view = viewer[0];
                        view.settings = data.Comments[i].Map;

                        viewer.before(`<span class="map-key">${data.Comments[i].Map.layerSelected}</span>`);
                    }

                    if (data.Comments[i].Graph && data.Comments[i].Graph.Keys != '') {
                        text.append("<div class='discussion-graph' id='discussion-graph-" + i + "' style='width: 888px'></div>");
                    }

                    // Editing and removing comments on hold
                    // text.append(removeComment);
                    // text.append(editComment);

                    $('.election-discussion .discussion-user').prepend(text);

                    if (data.Comments[i].Graph && data.Comments[i].Graph.Keys != '') {
                        getDiscussionGraphData('discussion-graph-' + i, data.Comments[i].Graph.Keys, data.Comments[i].Graph.TimeMin, data.Comments[i].Graph.TimeMax);
                    }

                    if (view && ECO.MINIMAP.initialized) {
                        ECO.MINIMAP.addView(view);
                    }
                }

                $(".current-rankings").hide();
            }
        };

        this.removeComment = function (comment) {
            comment  = JSON.stringify(comment);
            let data = {Username: election.username, Text: comment};

            $.ajax({
                url: APPIQUERYURL + "/api/v1/elections/removecomment?authtoken=" + election.authtoken,
                type: 'Post',
                dataType: 'Json',
                data: data,
                success: function (response) {
                    election.getAllComments(undefined, true);
                }
            })
        };

        /**
         * adding a comment
         */
        this.addComment = function (comment, isEdited) {

            if (typeof comment === typeof undefined) {
                comment = $('.election-discussion #comment').val().trim();
            }

            if (election.username == null || election.authtoken == null) {
                election.showError("To add comment you need to access from the game server");
                return false;
            }

            if (comment == "") {
                election.showError("The comment cannot be empty");
                return false;
            }

            // if (this.settings['availableCommentPages'].indexOf(getURLParameter("election")) < 0) {
            //     election.showError("You can't add comment for Previous Election.");
            //     return false;
            // }

            $('.error').empty().fadeOut();

            if (comment) {
                comment = comment.strip().replace(/\\n/, "<br>");

                let url = APPIQUERYURL + "/api/v1/elections/addcomment?electionId=" + getURLParameter("election") + "&authtoken=" + election.authtoken;
                const $mapData = $('#map-data');

                let data = {
                    'Username': election.username,
                    'Text': comment,
//                    'IsEdited': isEdited
                    'Tag': election.username
                };

                if ($('#graph-data').val().length) {
                    let graph = JSON.parse($('#graph-data').val());

                    data.Graph = {
                        "TimeMin": graph.time_start,
                        "TimeMax": graph.time_end,
                        "Keys":    graph.variables,
                    };

                    delete graph.variables;
                    delete graph.time_start;
                    delete graph.time_end;
                }

                if ($("#main-map").is(':visible') && $mapData.length && $mapData.val()/* && $('.fancy-add-graph').is(":hidden") */) {
                    data.Map = JSON.parse($mapData.val());
                }

                $.ajax({
                    beforeSend: function (xhrObj) {
                        xhrObj.setRequestHeader("Content-Type", "application/json");
                    },
                    url: url,
                    type: 'POST',
                    data: JSON.stringify(data),

                    success: function () {
                        location.reload();
                        // election.getAllComments(undefined,true);

                        // $('#graph-data').val('');

                        // $('#addGraph').attr('data-action', 'add').html('Add Graph').fadeIn();

                        // $('#removeGraph').fadeOut();
                        // $('.remove-map').fadeOut();
                        // $('#comment').val('');

                        // $('.comment-graph').remove();
                        // $('#graph_composer').remove();


                        // $("#map-control-wrapper").hide();
                        // $('.fancy-add-map').show();
                    },
                    error: function (error) {
                        election.showError(error);
                    }
                })
            }
        };

        /**
         *
         * Displays all speeches in the election
         * @param int  x - how many speeches to show
         *
         */
        this.displayAllSpeeches = function () {

            let count = $('.vote-item').find('p.candidate-name .candidate-speech').length;

            let characters = 100; //show "see more" link when the speech is have more than # characters

            let item = null;

            // let isVoted = $(".candidate-name#" + election.username).length;
            // if(isVoted){
            // 	$("a#add-self").html('Update Speech').attr('data-action', 'update');
            // 	$('#election-propose-button').html('Update Speech').attr('data-action', 'update');

            // 	$('#remove-self').css('display', 'inline-block');
            // }
            if (count) {

                $('.vote-item p.candidate-name .candidate-speech').each(function () {
                    if ($(this).html().length >= characters) {

                        item = $(this);

                        //include "see more" link only once
                        if (item.find('span').length != 0) {
                            return true;
                        }

                        // dividing speech into two parts
                        let text = item.html();

                        let p1 = text.substring(0, characters);

                        let p2 = text.substring((characters), text.length);

                        let user = item.parent().attr("data-id").replace(" ", "_");

                        item.html('');

                        // adding "see more" link
                        item.append("<span data-user=" + user + " class='part1'>" + p1 + "</span>");

                        item.append("<span class='read_more'>... <a> <i class='fa fa-fw fa-caret-down'></i></a> </span>");

                        item.append("<span style='display:none;' data-user=" + user + " class='part2'>" + p2 + "</span>");

                        // when a user clicks on "see more"
                        $(document).on('click', '.read_more', function () {

                            /* making visible whole speech and including "see_less" link */
                            let current = $(this).parents("p.candidate-name").attr('data-id').replace(" ", "_");

                            $(this).remove();

                            // $(this).parent().find(".see_less").remove();

                            $('.results-page').fadeOut();

                            $('.vote-page').css('width', '100%');

                            $('.candidate-speech p#' + current).find('.see_less').remove();

                            $('span.part2[data-user=' + current + ']').fadeIn();

                            $('span.part2[data-user=' + current + ']').after("<span class='see_less'> <a> <i class='fa fa-fw fa-caret-up'></i></a> </span>");


                        });

                        /* when a user clicks on "see less" */
                        $(document).on('click', '.see_less', function () {

                            /* Making only a part of speech visible and including "see_more" link */
                            let current = $(this).parents("p.candidate-name").attr('data-id').replace(" ", "_");

                            $(this).remove();

                            $(this).parent().find(".read_more").remove();

                            let count = $('.vote-item p .see_less').length;

                            if (count == 0) {

                                $('.results-page').fadeIn();

                                $('.vote-page').css('width', '55%');

                            }


                            $(this).remove();

                            $('span.part2[data-user=' + current + ']').fadeOut();

                            $('.candidate-speech p#' + current).find('.read_more').remove();

                            $('span.part1[data-user=' + current + ']').after("<span class='read_more'> ... <a><i class='fa fa-fw fa-caret-down'></i></a> </span>").fadeIn();
                        });
                    }
                })
            }
        };

        /**
         * Updating current election
         */
        this.updateCurrentElection = function () {

            $('#election-wrapper, .candidates-page').fadeOut();

            setTimeout(function () {

                election.getAllComments();

                election.showCandidates();

                $('.page:not(.results-page), #add-self, .law-discussion-textarea, .law-discussion-textarea + div, .info, .info + small, .vote-item+button ').fadeIn();

                $('#election-wrapper').fadeIn(); //?

                $('.vote-item p').each(function () {
                    if ($(this).id == election.username && typeof $(this).id != typeof undefined) {
                        $('#remove-self').fadeIn();
                        return false;
                    }
                })
            }, 500);

        };

        /**
         * voting
         */
        this.vote = () => new Promise(async(resolve, reject) => {
            if (election.username == null || election.authtoken == null) {
                election.showError("To vote you must be logged in.");
                return reject();
            }

            let rankedVotes = [];

            if (election.electionData.BooleanElection) {
                rankedVotes.push($("input[name=options]:checked").data('choiceId'));

                $('input[name=options]:not(:checked)').each(function() {
                    rankedVotes.push($(this).data('choiceId'));
                });
            } else {
                $('#ranked-election-vote-wrapper .add-self-wrapper').children('.vote-item').each(function(i) {
                    rankedVotes[i] = $(this).data('user');
                });

                if (!rankedVotes.length) {
                    election.showError("No candidates were ranked.");
                    return reject();
                }
            }

            $('.error').empty().fadeOut();

            try {
                //make an ajax request to send vote to the server
                await $.ajax({
                    method: "post",
                    url: APPIQUERYURL+'/api/v1/elections/vote?authtoken='+election.authtoken,
                    beforeSend: xhrObj => {xhrObj.setRequestHeader("Content-Type", "application/json")},
                    data: JSON.stringify({
                        ElectionID: election.electionData.Id,
                        Voter: election.username?.escapeQuotes(),
                        RankedVotes: rankedVotes
                    }),
                });

                resolve();
            } catch (e) {
                election.showError(e);
                reject();
            }
        });

        function updateInfo(data, guid) {
            let isPrevious = (data.Finished); //$('.previous-election.active-election').length;

            // updating election info
            if (data instanceof Array) {
                data = data[0];
            }
            // if (data.Candidates.length != 0) {


            let info = "";
            let timeItem = '';
            let timeToEnd = '';
            let updateTimer = () => {};
            if (isPrevious !== false) {
               let prevEnded = ConvertSeconds(data.TimeEndAgo);
                timeItem = "<li><span class='localize' translate-key='153'>Ended</span>  " + prevEnded + " <span class='localize' translate-key='154'>ago</span></li>";
                // info += "<li>" +(data.Results.Winner != "") ? "<span class='localize' translate-key='159'>The winner was</span> " + data.Results.Winner + ".</li>" : "There was no winner.</li>";
            } else {
                let timeSinceAgo = ConvertSeconds(data.TimeStartAgo);
                timeItem = "<li><span class='localize' translate-key='170'>Since</span>  <span id='timerElectionsStartedAgo'>" + ConvertSeconds(data.TimeStartAgo) + "</span> <span class='localize' translate-key='154'>ago</span></li>";
                let systemTimeAtTimerStart = Date.now() / 1000;

                if (data.TimeEndAgo)
                {
                    timeToEnd = "<li><span class='localize' translate-key='173'>Voting will end in </span>  <span id='timerToElectionEnd'></span> </li>";
                }

                updateTimer = () =>
                {
                    let secondsFromStart = Date.now() / 1000 - systemTimeAtTimerStart;
                    $("#timerToElectionEnd").html(ConvertSeconds(Math.max(0, -data.TimeEndAgo - secondsFromStart) ));
                    $("#timerElectionsStartedAgo").html(ConvertSeconds(data.TimeStartAgo + secondsFromStart));
                }
                setInterval(updateTimer, 1000);
            }

            info += timeItem + timeToEnd;
            // }

            let names = [];

            data.Choices.forEach(function (item, index) {
                names.push(item.Name);
            });

            $('#candidate-names').val(JSON.stringify(names));

            $('.current-rankings table tr:first-of-type td').html("<span class='localize' translate-key='134'>All Votes</span>");
            votersCount = data.TotalVotes;

            $('.candidate-speech p').remove();

            $('.vote .vote-item').remove();
            let res = isPrevious ? "Final Results" : "Current Results";

            $('.section-title-results span').empty().append(res);

            info += "<li>" + data.TotalVotes + (data.TotalVotes == 1 ? " <span class='localize' translate-key='148'>vote</span>" : " <span class='localize' translate-key='149'>votes</span>") + " <span class='localize' translate-key='132'>total</span>. </li>";

            // let winnerInfo;

            /*	if(isPrevious == 0 && typeof guid == typeof undefined){
                        info += (data.Results.Winner == "") ? "<li>Winner will become the world leader.</li>" : "<li>Winner will replace current leader: <span class='text-highlight'> " + data.Results.Winner + "</span>.</li>";
                    }*/
            /* if(isPrevious == 0 && typeof guid == typeof undefined && data.Results.Result != 'Election ends in a tie. No winner.'){
                let leaderReplace = (data.Results.Winner == "") ? " and will become the world leader." : " and will replace " + data.Results.Winner + " as world leader.";
            } else { let leaderReplace = ''; }*/

            let leaderReplace = '.';

            for (let mapData of [data.DistrictMapAfter, data.DistrictMapBefore]) {
                if (mapData) {
                    let $wrapper = $("<div class='law-discussion-wrapper'></div>");
                    let $section = $("<div class='comment-section1'></div>");
                    $wrapper.append($section);

                    let $viewer = $('</div><div id="main-map" class="view-map"></div>');

                    if (mapData == data.DistrictMapBefore) {
                        $viewer.append('<input type="button" data-type="3" value="3D" id="map-toggle-2d">');
                    }

                    $section.after($viewer);

                    mapData.shareCamera = true;

                    view          = $viewer[0];
                    view.settings = mapData;

                    $("#choise-election-wrapper").prepend($wrapper);

                    if (view && ECO.MINIMAP.initialized) {
                        ECO.MINIMAP.addView(view);
                    }
                }
            }

            if (isPrevious === false && typeof guid === typeof undefined) {
                info += "<li><b><span class='localize' translate-key='147'>Projected result:</span></b> " + data.Results.Result + leaderReplace + "</li>";
            }

            if (data.ResultsDescription) {
                //   info += "<li>" + data.Results.StatusMessage + "</li>";
                info += "<li>" + data.ResultsDescription + "</li>";
            }

            if (!data.BooleanElection) {
                let runoffVotingTemplate = $.templates("#election-run-off-voting-template");
                info += runoffVotingTemplate.render();
            }

            $('.election-info').html(info);
            updateTimer();
        }

        /**
         *  show candidates and their speeches
         */
        this.showCandidates = function (guid) {
            if (currentPage !== "elections") return false;

            let url = null;

            let isPrevious = $('.previous-election.active-election').length;
            //$('#elections-page-instructions-wrapper').hide();

            //disable selects when the previous page is loaded
            let active = "";

            // if (isPrevious === 0 && typeof guid === typeof undefined) {
            //     type = 'current'
            // } else {
            //     type = 'previous';
            //     active = "disabled";
            // }

            let rank = 0,
                candidates_count = 0,
                candidates_votes = [],
                votersCount = 0,
                _this = this;

            this.getElectionById(guid, showCandidates);

            function showCandidates(data) {
                election.runningElection = data;

                updateInfo(data, guid);

                //votes per round table
                let results = data.Results.ChoiceRanks;
                let rounds = 0;
                window.results = results;

                results = results.sort(function (a, b) {
                    a = a.VotesPerRound[a.VotesPerRound.length - 1];
                    b = b.VotesPerRound[b.VotesPerRound.length - 1];
                    return b - a;
                });

                if (data.BooleanElection) {
                    let vData = new class votesCollection extends Array {
                        sum(key) {
                            return this.reduce((a, b) => a + (b[key] || 0), 0);
                        }
                    };

                    let electionChoices = data.Choices;

                    electionChoices.forEach((item) => {
                        let r = results.find(resultItem => resultItem.ChoiceID === item.Id);
                        if (r !== undefined) {
                            vData.push({
                                name: item.Name,
                                y: r.Votes
                            })
                        }
                    });

                    let totalVotes = vData.sum('y');

                    if (totalVotes) {
                        let electionsGraph = new ElectionVotingGraph("election-chart-voting-results-container");
                        electionsGraph.draw(vData);
                    }
                }

                let candidates_ordered_arr = [];

                results.forEach(function (item, index) {
                    if (item.VotesPerRound.length > rounds) {
                        rounds = item.VotesPerRound.length;
                    }

                    for (let idx = 0; idx < data.Choices.length; idx++) {
                        let elem = data.Choices[idx];
                        let domElem = document.createElement("z");
                        domElem.innerHTML = item.MarkedUpName;
                        let domElemText = domElem.innerText;
                        if (domElemText.toLocaleLowerCase() === elem.Name.toLocaleLowerCase()) {
                            candidates_ordered_arr.push(elem);
                            break;
                        }
                    }
                });

                data.Candidates = candidates_ordered_arr;
                /*/styling table
                if(rounds <= 3){
                    $('.votes-per-round table').css('width', "74%");
                }else if(rounds <= 5){
                    $('.votes-per-round table').css('width', "85%");
                }else{
                    $('.votes-per-round table').css('width', "100%");
                }*/

//                if no one has voted yet
                if (rounds == 0) {
                    $(".no-votes").show();
                    $(".votes-per-round table, .current-rankings, .view-all-votes").css("display", "none");
                } else {
                    $(".votes-per-round table").show();
                    $(".no-votes").hide();
                }

                $('.votes-per-round table tr:not(.title-heading)').remove();

                $('.votes-per-round table tr:first-of-type td').attr('colspan', rounds + 1);

                let row = $("<tr class='table-top'> <td class=' table-top-left'> <span class='localize' translate-key='25'>Candidates</span> </td> </tr>");

                for (let i = rounds; i > 0; i--) {
                    row.append("<td><span class='localize' translate-key='131'>Round</span>  " + i + "</td>");
                }

                $('.votes-per-round table').append(row);

                if (data.PositionForWinner !== undefined) {

                    let positionForWinnerTableTemplate = $.templates("#position-for-winner-table-template");
                    let html = positionForWinnerTableTemplate.render(data.PositionForWinner);

                    $("#position-for-winner-table").html(html);

                    $('#position-for-winner-table .flat-table .table-middle:odd').addClass("table-alternating-color-1");
                    $('#position-for-winner-table .flat-table .table-middle:even').addClass("table-alternating-color-2");
                }

                // Moved modal table generation here to get it work for Prev. Elections
                if ($('#candidate-names').length !== 0) {
                    // Added delay for the DOM to be generated:
                    setTimeout(() => {setupTable(guid)}, 1500);
                }

                let candidates = data.Candidates;
                if (candidates.length === 0) return false;

                candidates_count = candidates.length;

                $('.candidates-page .candidate-name').empty();

                let cycleLength = candidates.length;

                for (let i = 0; i < cycleLength; i++) {
                    //appending candidate names into "votes per round" table
                    let r = $(`<tr class="table-middle" data-candidate="${candidates[i].Id}"><td class="table-left">${candidates[i].Name}</td></tr>`);

                    for (let td = rounds; td > 0; td--) {
                        r.append("<td class='round-vote' data-round = '" + (td) + "'> </td>");
                    }

                    $('.votes-per-round table').append(r);

                    if (candidates[i].Speech !== undefined) {
                        let voteId   = encodeURIComponent(candidates[i].Id);

                        let row = $(`<div class="vote-item grab" data-user="${voteId}"></div>`);
                        row.append('<span>&#x21C5;</span>');
                        row.append('<div class="choice"><span>#1</span></div>');

                        row.append(`<p data-id="${voteId}" class="candidate-name" id="${voteId}">
                            <span class="candidate-name-title">${candidates[i].Name}</span>
                            <span class='candidate-speech'>${decode(candidates[i].Speech)}</span>
                        </p>`);

                        $('.vote button').before(row);

                        if (candidates[i].CandidateName === election.Creator && typeof guid === typeof undefined) {
                            $('a#add-self').hide();
                            $('#add-self').html('update speech').attr('data-action', 'update');
                            $('#election-propose-button').html('Update Speech').attr('data-action', 'update');
                            $('#remove-self').css('display', 'inline-block');
                        }
                    } else {
                        rank++;
                    }
                }

                if ($('.candidate-name').length) {
                    let $voteBtn  = $('#choice-election-vote-wrapper .vote-button').detach().hide();
                    let $wrapper  = $('#choice-election-vote-wrapper');
                    let $dragzone = $wrapper.clone().attr('id', 'ranked-election-vote-wrapper');

                    $dragzone.find('.vote-item').remove();
                    $dragzone.find('#election-vote').append($voteBtn);
                    $dragzone.prepend('<div id="section-title" data-toggle="tooltip" data-container="body" data-placement="left" title="" data-original-title="Click and drag the candidates to put them in your order of preference. If your first choice doesn\'t have enough votes to win, your second choice will be used, etc."><p style="width:100%" class="localize" translate-key="133">Candidates Ranked</p></div>');
                    $dragzone.find('.add-self-wrapper').html('<span class="vote-drag-box">Drag candidates here to vote</span>');

                    $wrapper.after($dragzone);

                    if (!data.Finished) {
                        $('#choice-election-vote-wrapper .add-self-wrapper, #ranked-election-vote-wrapper .add-self-wrapper').sortable({
                            helper:      'clone',
                            connectWith: ".add-self-wrapper",
                            items:       '> .vote-item',
                            start(e, ui) {
                                ui.helper.css('margin-top', $(window).scrollTop());
                            },
                            receive() {
                                let $voteItems = $('#ranked-election-vote-wrapper .add-self-wrapper .vote-item');
                                $('#ranked-election-vote-wrapper .add-self-wrapper > span')[$voteItems.length ? 'hide' : 'show']();
                            },
                            update() {
                                let $voteItems = $('#ranked-election-vote-wrapper .add-self-wrapper .vote-item');
                                $('#choice-election-vote-wrapper .add-self-wrapper .vote-item .choice').hide();

                                $voteItems.each(function (i) {
                                    $(this).find('.choice').css('display', 'inline-block').find('span:eq(0)').text((++i));
                                });

                                $voteItems.length ? $voteBtn.show() : $voteBtn.hide();
                            }
                        }).disableSelection();
                    } else {
                        // Remove hand grab cursor from candidates
                        $('.grab').removeClass('grab');
                    }
                }

                election.displayAllSpeeches();

                //updating data in votes per rounds table
                let novotes = 0;

                results.forEach(function (item, index) {
                    //getting each candidate votes
                    let v = item.VotesPerRound;
                    if (v.length == 0) {
                        novotes++;
                    }

                    $(`.votes-per-round table tr[data-candidate="${encodeURIComponent(item.ChoiceID)}"] td`).each(function() {
                        let roundNumber = $(this).attr('data-round');

                        if (typeof roundNumber != typeof undefined) {
                            let count = (typeof v[roundNumber - 1] != "undefined") ? v[roundNumber - 1] : "X";

                            $(this).html(count);

                            //make X's red
                            if (count == "X") {
                                $(this).addClass('red');
                            }
                        }
                    })
                });

                //making each column's high value bold
                for (let i = 1; i <= rounds; i++) {
                    let max = 0;

                    $(`.votes-per-round table td[data-round="${i}"]`).each(function () {

                        if ($(this).html() != "X") {
                            let value = parseInt($(this).html());
                            if (value > max) {
                                max = value;
                            }
                        }
                    });
                }

                let total = $('<tr class="table-bottom"><td><span class="localize" translate-key="132">Total</span></td></tr>');

                for (let i = rounds; i > 0; i--) {
                    let round = 0;

                    $('.votes-per-round tr td').each(function () {
                        if (typeof $(this).data('round') != "undefined") {
                            if ($(this).data('round') == i && $(this).html() != "X") {
                                round += parseInt($(this).html());
                            }
                        }
                    });

                    total.append("<td data-total='" + (i + 1) + "'>" + round + "</td>");
                }

                $('.votes-per-round table').append(total);

                /* sorting the "votes per round" table */
                _this.getVote(guid, tableShow);

                function tableShow(data) {
                    //if user already voted
                    data.forEach(function (item, index) {
                        if (item.Voter === election.username) {
                            $('.vote-button').html('<span class="localize" translate-key="130">Update Vote</span>');
                        }
                    });

                    let cycleLength = data.length;

                    for (let i = 0; i < cycleLength; i++) {
                        let newCycleLength = data[i].RankedVotes.length;
                        for (let j = 0; j < newCycleLength; j++) {
                            $(`.current-rankings table tr[data-voter-i="${i}"] td`).each(function () {
                                let user = $(this).data('user');

                                if (typeof user != "undefined") {
                                    let rank = $.inArray(user, data[i].RankedVotes);
                                    if (rank == -1) {
                                        $(this).html("");
                                    } else {
                                        rank = rank + 1;
                                        $(this).attr("data-value", rank);

                                        if (election.electionData.BooleanElection) {
                                            rank = rank === 1 ? '<i class="fa fa-check bool-choice-value"></i>' : '';
                                        }

                                        $(this).html(rank);
                                    }
                                }
                            })
                        }
                    }
                }

                $('.vote-item select option').remove();
                for (let j = 0; j <= candidates_count - rank; j++) {
                    if (j === 0) {
                        $('.vote-item select').append("<option value='0'> - </option>");
                    } else {
                        $('.vote-item select').append("<option value='" + j + "'>" + j + "</option>");
                    }
                }
            }
        };

        /**selected="selected"
         * remove yourself from the candidates list
         */
        this.removeSelf = function () {
            let speech = $(".vote-item  p#" + encodeURIComponent(election.username)).html();
            let url    = APPIQUERYURL + "/api/v1/elections/removecandidate?authtoken=" + election.authtoken + "&speech=" + speech;

            $.post(url, function (status, data) {
                $('.current-election').trigger('click');
            })
        };

        /* loads previous elections pages */
        this.loadElectionPage = function (id, update = false) {

            let electionCallback = (electionData) => {
                $('#elections-page-instructions-wrapper').hide();

                this.showCandidates(id);
                this.getAllComments(id);
                this.showElectionName(electionData);
                this.showElectionProcessLink(electionData);

                let hideVoting = (electionData.Finished || !this.authtoken);

                if (electionData.BooleanElection) {
                    // Simply moved method call here to get rid of condition doubling
                    this.showElectionActionOnCompleteTable(id);

                    let candidatesTemplate   = $.templates("#boolean-election-voting-template");
                    let yesNoChoicesTemplate = $.templates("#yes-no-vote-items");

                    $(".multi-choice-election").hide();
                    $("#choice-election-vote-wrapper").prepend(candidatesTemplate.render(electionData));
                    $("#election-vote .add-self-wrapper").prepend(yesNoChoicesTemplate.render(electionData));

                    $('.eco-button.vote-button').hide();

                    if (hideVoting) {
                        $(".choice-election-vote-wrapper").hide();
                    }
                } else {
                    let candidatesTemplate = $.templates("#choice-election-voting-template");

                    $("#choice-election-vote-wrapper").prepend(candidatesTemplate.render());
                    $("#election-chart-voting-results-container").hide();
                }

                if (electionData.Finished || !this.authtoken) { // if not running election
                    $(' #add-self, .vote p.info, .election-comment, .election-comment + div, .info + small, .vote-button').hide();
                    $(".vote-item select").hide();
                    $(".bool-choice-controls").hide();
                } else {
                    //$(' #add-self, .vote p.info, .election-comment, .election-comment + div, .info + small, .vote-button').show();
                }

                $('#election-wrapper, #wrapper, .vote-page').show();
                $(".current-rankings").show();
            };

            // Force to re-fetch election data if needed
            this.getElectionById(id, electionCallback, update);
        };


        // /* show the most recent election */
        // this.showRecent = function(){
        // 	let url = APPIQUERYURL + "/api/v1/elections/previous";
        // 	$.get(url, function(data, status){
        // 		if(status == "success"){
        // 			let recent = data.sort(function(a,b){
        // 				return a.TimeEndAgo-b.TimeEndAgo;
        // 			})[0].Guid;
        //
        // 			election.loadElectionPage(recent);
        //
        // 		}
        // 	})
        //
        // }

        // call setupTable funcion from election object
        this.setupTable = function (guid) {
            setupTable(guid);
        }
    };

    function getURLParameter(name) {
        return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null
    }

    /**
     *  Setting up current rankings table
     */
    function setupTable(guid) {

        election.getVote(guid, setupTable);

        function setupTable(data) {
            // Re-create the picture of own vote (if voted)
            for (let vote of data) {
                if (vote.Voter.toLowerCase() == election.username?.toLowerCase()) {
                    let $wrapper = $('#election-vote .add-self-wrapper');
                    let $ranked  = $('#ranked-election-vote-wrapper .add-self-wrapper');

                    for (let candidate of vote.RankedVotes) {
                        $wrapper.find(`.vote-item[data-user="${encodeURIComponent(candidate)}"]`).appendTo($ranked);
                    }
                }
            }

            let candidateNames = $('#candidate-names');
            if (candidateNames.length === 0 || !candidateNames.val()) {
                return false;
            }

            /* getting the candidates data to include it on the table */
            let candidates = JSON.parse(candidateNames.val());

            /* changing font size of the table depending on the data length */
            let fontSize = "20px";
            let w = "25%";

            if (candidates.length > 10) {
                fontSize = "14px";
                w = "50%";
            } else if (candidates.length > 15) {
                fontSize = "10px";
                w = "70%";
            } else if (candidates.length > 25) {
                fontSize = "10px";
                w = "100%";
            }
            //$('.current-rankings table').css({"width": w, "font-size": fontSize });

            /* UPDATING THE TABLE*/

            /* first: removing all rows except heading */
            $('.current-rankings table tr:not(:first-child)').remove();
            let cycleLength = data.length;
            /* appending updated rows based on the candidates data */
            for (let i = 0; i <= cycleLength + 1; i++) {
                let row = $("<tr> </tr>");
                let newCycleLength = candidates.length;

                for (let j = 0; j <= newCycleLength; j++) {
                    if (i == 0 && j == 0) {
                        if (!election.electionData.BooleanElection) {
                            let headerStr = "<td class='table-key' colspan='" + candidates.length + "'> <span class='localize' translate-key='133'>Candidates Ranked</span> </td>";
                            row.append(headerStr);
                        }
                    } else if (j == 0 && i != 1) {
                        row.append("<td> " + data[i - 2].Voter + "</td>");
                        row.attr('data-voter', encodeURIComponent(data[i - 2].Voter.trim()));
                        //voter index, since voter name maybe duplicated in case of anonymous voting
                        row.attr('data-voter-i', i - 2);
                        row.attr('class', 'table-middle');
                    } else if (j == 0) {
                        if (i == 1) {
                            row.append(`<td class="table-top table-top-left table-key"><span class="localize" translate-key="135">Voters</span></td>`);
                        }
                    } else if (i == 1) {
                        row.append(`<td class="table-top">${candidates[j - 1]}</td>`);
                    } else if (i != 0) {
                        // Determine if user voted Yes or No:
                        let mark = '';

                        // Looking for choice name by choice id
                        election.electionData.Choices.forEach((choice, index) => {
                            if (choice.Id == data[i - 2].RankedVotes[0]) {
                                mark = j == index + 1 ? '✓' : '';
                            }
                        });

                        row.append(`<td class="rank" data-user="${encodeURIComponent(candidates[j - 1].trim())}" data-rank="${j}">${mark}</td>`);
                        row.attr('class', 'table-middle');
                    }
                }

                $('.current-rankings table').append(row);
            }
            /* making the first row of the table to take all space */
            $('.current-rankings table tr:first-child td').attr('colspan', candidates.length + 1);

            //Sideways Y-axis Title
            //$('.current-rankings .table-left:first').append("<div class='table-key-left'>VOTERS</div>");

            //Alternating colors on tables
            $('.flat-table .table-middle:odd').addClass("table-alternating-color-1");
            $('.flat-table .table-middle:even').addClass("table-alternating-color-2");


            //updating the selects based on the user's selections (no delay, cuzz added global one)
            let userSelection = $(`.current-rankings tr[data-voter="${encodeURIComponent(election.username)}"]`);

            if (!userSelection.length && $('.active-election').length) {
                $(".vote-item select").hide();
                return false;
            }

            let obj = [];

            userSelection.find("td.rank").each(function () {
                let item = {};
                item.candidate = $(this).attr("data-user");
                item.vote      = $(this).attr("data-rank");
                obj.push(item);
            });

            obj.forEach(function (elm) {
                $(`.vote-item[data-user="${encodeURIComponent(elm.candidate)}"] select option[value="${elm.vote}"]`).attr("selected", "selected");
            });

            if (election.electionData.BooleanElection) {
                let currentVote = data.find(x => x.Voter === election.username);

                if (currentVote) {
                    let currentChoice = currentVote.RankedVotes[0];
                    let currentChoiceControl = $("#bool-choice-input-" + currentChoice);
                    currentChoiceControl.parent().addClass("active");
                    currentChoiceControl.attr("checked", "checked");
                }
            }
        }
    }


// converts seconds into days, hours, minutes
    function ConvertSeconds(seconds, mode, x) {

        //converting seconds into a number
        seconds = parseFloat(seconds);

        let result = "";

        //getting days
        let days = parseInt(seconds / 86400);

        //getting hours
        let hours = parseInt((seconds - (86400 * days)) / 3600);

        let middle = (86400 * days) + (3600 * hours);

        //getting minutes
        let minutes = parseInt((seconds - middle) / 60);

        //constructing the return text
        if (days !== 0) {
            result += days + " " + ((days === 1) ? "<span class='localize' translate-key='38'>day</span> " : "<span class='localize' translate-key='155'>days</span> ");
        }

        if (hours !== 0) {
            result += hours + " " + ((hours === 1) ? "<span class='localize' translate-key='143'>hr</span> " : " <span class='localize' translate-key='156'>hrs</span> ");
        }

        if (minutes !== 0) {
            result += minutes + " " + ((minutes === 1) ? "<span class='localize' translate-key='144'>min</span> " : "<span class='localize' translate-key='157'>min</span> ");
        }

        if (days === 0 && hours === 0 && minutes === 0) {
            result = parseInt(seconds) + " secs";
        }

        //the case when we want to get only day and hour
        if (typeof mode !== typeof undefined) {

            if (typeof x === typeof undefined) {

                return {'day': days, 'hour': hours};

            } else if (x === "day") {

                return {'day': days};

            } else if (x === "hour") {

                let hour = parseInt(seconds / 3600);

                return {'hour': hour};

            }

        }

        return result;

    }

    function decode(string) {
        let encodedStr = string.replace(/[\u00A0-\u9999<>&]/gim, function (i) {
            return '&#' + i.charCodeAt(0) + ';';
        });
        return encodedStr;
    }

    function sum(x) {
        if (x === 1) {
            return 1;
        } else {
            return x + sum(x - 1);
        }
    }

// create unique election object
    let election = new Election();

    $(document).ready(function () {
        if (typeof bindAllElectionEvents !== 'undefined' && $.isFunction(bindAllElectionEvents))
            bindAllElectionEvents(election);
    });

    // Flip chevron on collapse/explode section
    $(document).on('show.bs.collapse', '.panel-collapse', function() {
        $(this).prev().find('.glyphicon').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
    });

    $(document).on('hide.bs.collapse', '.panel-collapse', function() {
        $(this).prev().find('.glyphicon').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
    });
})();