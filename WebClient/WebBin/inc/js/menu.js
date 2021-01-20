/* menu Saved Discussions */
function SavedDiscussions(data) {
    let html = '';
    if (data.length) {
        let classId = '';
        if (currentPage == 'discussion') {
            classId = getURLParameter('classId');
        }
        for (let i in data) {
            if (classId == data[i].Guid) {
                html += "<li class='menu-highlight'><a href='/discussion.html?classId=" + data[i].Guid + "' id='" + data[i].Guid + "'>" + data[i].Title + "</a></li>";
            } else {
                html += "<li><a href='/discussion.html?classId=" + data[i].Guid + "' id='" + data[i].Guid + "'>" + data[i].Title + "</a></li>";
            }
        }
        $('#save-discussion > a').html("Saved Discussions <span class='caret'></span>");
        $('#menu-save-discussion').append(html);
    } else {
        $('#save-discussion > a').html("No Saved Discussions").addClass('menu-no-link');
    }
}

/* menu Run For Office */
// function RunForOfficeMenu(data) {
//      setTimeout(function(){
//     $('a#add-self').hide();
//     $('#add-self').html('update speech');
//     $('#add-self').attr('data-action', 'update');
//     $('#election-propose-button:not(.eco-button)').html('Update Speech').attr('data-action', 'update');
//
//      },500)
// };


/* menu Previous Elections */
function PreviousElectionsMenu(data) {
    if (data.length == 0) {
        $('#previous-elections-wrapper').hide();
        $('li#previous-elections > a').html("<i class=\"fa fa-fw fa-check-square-o\"></i><span class='localize' translate-key='140'>No Previous Elections</span>");
        $('li#previous-elections > a').addClass('menu-no-link');
        return false;
    } else {

        //adding previous elections
        $('li#previous-elections > a').html("<i class=\"fa fa-fw fa-check-square-o\"></i><span class='localize' translate-key='53'>Previous Elections </span><span class='caret'></span>");
        $('.previous-elections-wrapper').empty();

        //sorting in order to show the most recent election first
        data.sort(function (a, b) {
            return a.TimeEndAgo - b.TimeEndAgo;
        });

        for (let i = 0; i < data.length; i++) {
            let highlight = "";

            if (data[i].Id === parseInt(getURLParameter("election"))) {
                highlight = "menu-highlight";
            }
            let item = $("<li class='" + highlight + "'><a href='/elections.html?election=" + data[i].Id + "' class='previous-election' data-guid = '" + data[i].Id + "'><span>" +  data[i].Name  + "</span></li>");
            $('.previous-elections-wrapper').append(item);
        }
    }
}

function TitlesMenu(data) {
    let $menuOfficials = $('li#current-elected-officials > a');
    if (data.length === 0) {
        //Change text, style and disable link
        $menuOfficials.html('<i class="fa fa-fw fa-university"></i><span class="localize" translate-key="175">No Active Titles</span>');
        $menuOfficials.addClass('menu-no-link');
        $menuOfficials.removeAttr('href');
    } else {
        //Change text, put back link
        $menuOfficials.html('<i class="fa fa-fw fa-university"></i><span class="localize" translate-key="162">Elected officials</span>');
        $menuOfficials.attr('href', '/electionTitles.html');
    }
}

function RunningElectionsMenu(data) {
    if (data.length === 0) {
        $('#running-elections-wrapper').hide();
        $('li#running-elections > a').html("<i class=\"fa fa-fw fa-bar-chart\"></i><span class='localize' translate-key='164'>No Running Elections</span>");
        $('li#running-elections > a').addClass('menu-no-link');
        return false;
    } else {

        //adding previous elections
        $('li#running-elections > a').html("<i class=\"fa fa-fw fa-bar-chart\"></i><span class='localize' translate-key='163'>Running Elections</span><span class='caret'></span>");
        $('.running-elections-wrapper').empty();

        //sorting in order to show the most recent election first
        // data.sort( function(a,b){
        //     return a.TimeEndAgo - b.TimeEndAgo;
        // })

        for (let i = 0; i < data.length; i++) {
            let highlight = "api/v1/elections";

            if (data[i].Id === parseInt(getURLParameter("election"))) {
                highlight = "menu-highlight";
            }
            let icon = data[i].PendingVote ? '<i class="fa fa-exclamation-circle" style="color:red" data-toggle="tooltip" data-container="body" data-placement="right" title="You have not voted on this issue."></i>' : '';
            let item = $("<li class='" + highlight + "'><a href='/elections.html?election=" + data[i].Id + "' class='running-election' data-guid = '" + data[i].Id + "'><span>" + data[i].Name +  "  </span>" + icon + "</a></li>");
            $('.running-elections-wrapper').append(item);
        }
    }
}


/* menu Active and Proposed Laws*/
function ActiveProposedLawsMenu(data) {
    //Active Laws
    let activeLaws = false;
    let lawsActiveHtml = "";

    //Proposed Laws
    let proposedLaws = false;
    let proposedLawsHtml = "";

    $.each(data, function (index, words) {
        let highlight = "";
        if (words.Id === parseInt(getURLParameter("lawid"))) {
            highlight = "menu-highlight";
        }

        if (words.State === "Active") {
            activeLaws = true;
            if (words['Period'] < 2) {
                day = 'day';
            } else {
                day = 'days';
            }

            lawsActiveHtml += "<li class='" + highlight + "'><a href='/laws.html?lawid=" + words.Id + "' id='" + words.Id + "'><span class='laws-title'>" + words.Name + "</span><br/>";
            //lawsActiveHtml += "Each player may not "+words['Action']+" more than "+words['Value']+" "+words['Target']+" per day.<br/>";
            lawsActiveHtml += "</a></li>\n";
        } else {
            proposedLaws = true;
            if (words['Period'] < 2) {
                day = 'day';
            } else {
                day = 'days';
            }
            ;
            proposedLawsHtml += "<li class='" + highlight + "'><a href='/laws.html?lawid=" + words.Id + "' id='" + words.Id + "' href='/index.html?lawid=" + words.Id + "'><span class='laws-title'>" + words.Name + "</span><br/>";
            //proposedLawsHtml += "<li class='" + highlight + "'><a href='/laws.html?lawid=" + words['Guid'] + "' id='" + words['Guid'] + "' href='/index.html?lawid=" + words['Guid'] + "'><span class='laws-title'>" + words['Title'] + "</span><br/>";
            //proposedLawsHtml += "Each player may not "+words['Action']+" more than "+words['Value']+" "+words['Target']+" per day.<br/>";
            // proposedLawsHtml += "<span class='laws-menu-voting'><span class='laws-menu-voting-yes'>" + words['VotesYes'] + " <span class='localize' translate-key='78'>YES</span></span> &nbsp; <span class='laws-menu-voting-no'>" + words['VotesNo'] + " <span class='localize' translate-key='79'>NO</span></span></span><br/>";
            proposedLawsHtml += "</a></li>\n";
        }
    });

    //showing the message if there's no active or proposed laws
    if (!proposedLaws) {
        $('#proposed-laws > a').html("<span class='localize' translate-key='102'>No Proposed Laws</span>")
        $('#proposed-laws > a').addClass('menu-no-link');
    } else {
        $('#proposed-laws > a').html("<span class='localize' translate-key='57'>Proposed Laws <span class='caret'></span>");
        $('#proposed-laws ul li').remove();
        $('#proposed-laws ul').append(proposedLawsHtml);
    }

    if (!activeLaws) {
        $('#active-laws > a').html("<span class='localize' translate-key='101'>No Active Laws")
        $('#active-laws > a').addClass('menu-no-link');
    } else {
        $('#active-laws > a').html("<span class='localize' translate-key='56'>Active Laws <span class='caret'></span>");
        $('#active-laws ul li').remove();
        $('#active-laws ul').append(lawsActiveHtml);
    }
}
