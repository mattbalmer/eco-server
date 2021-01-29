function bindAllElectionEvents(election) {
    let specificElection = getURLParameter("election");

    if (specificElection) {
        election.loadElectionPage(specificElection);
    }

    // see more link for speeches
    election.displayAllSpeeches();

    //show the most recent election
    // var  recent = getURLParameter("showrecent");
    //
    // if(recent && recent == "true"){
    // 	election.showRecent();
    // }

    $(".view-all-votes").click(function () {
        $('#allVotes').modal('toggle');
        content = $(".fancy-all-votes");
        $(".current-rankings").fadeIn();
    });


    //removing comment
    $(document).on('click', '#removeComment', function () {
        let content = $(this).parent().find('.law-discussion-comment').html();
        election.removeComment(content, $(this).data('graph'));
    });

    //editing comment
    let commenttext = "";
    $(document).on('click', '#editComment', function () {

        $('.comment-graph').remove();

        $('#graph-data').val('');

        commenttext = $(this).parent().find('.law-discussion-comment').html();

        $(".election-comment").val(commenttext);

        window.scrollTo(0, document.body.scrollHeight);

        let graphs = $(this).attr('data-graph');

        if (graphs != "") {

            $('#graph-data').val(graphs);
            $('.edit-comment-buttons').show();

            $('.election-comment').css('margin-right', '10px');

            $('.comment-graph').remove();

            $('.edit-comment-buttons #removeGraph').fadeIn();

            var composer = $("<iframe class='comment-graph' id='graph_composer' src='graph_composer/index.html'> </iframe>");

            $(".election-comment").before(composer);

            $('.comment-graph').fadeIn();

        } else {
            $('#removeGraph').hide();

            $('.edit-comment-buttons').show();

            $('.election-comment').css('margin-right', '10px');

        }

        $('.add-comment-buttons').hide();

        // removing graph
        $(document).on('click', '.edit-comment-buttons #cancel-edit', function () {
            $('.comment-graph').remove();
            $('.election-comment').val('');
            $('.edit-comment-buttons').hide();
            $('.add-comment-buttons').show();
            $('#graph-data').val('');
        })

    });

    //submit
    $(document).on('click', '.edit-comment-buttons #submit', function () {

        election.removeComment(commenttext);

        let comment = $('#comment').val();

        setTimeout(function () {

            election.addComment(comment, true);

        }, 500);
        $('.election-comment').val('');
        $('.edit-comment-buttons').hide();
        $('.add-comment-buttons').show();
    });

    //enable vote button when the select has changed
    $(document).on('change', '.vote-item select', function () {
        $('.vote-button').removeAttr('disabled');
    });

    //adding graph without fancybox
    $(document).on('click', '#addGraph', function () {
        let $composer = $("<iframe class='comment-graph' id='graph_composer' src='graph_composer/index.html' style='display: none'> </iframe>");
        $(this).hide();

        if ($('iframe.comment-graph').length > 0) {
            $('.iframe.comment-graph').remove();
        }

        $("#graphContainer").append($composer);

        $composer.slideDown();
        $('html, body').animate({scrollTop: $composer.offset().top - 200});

        $('#removeGraph, .remove-graph-button').css({'display': 'inline-block', 'color': '#ababab', 'text-decoration': 'line-through'}).show();
    });

    //showing results table
    $(document).on("click", '.show-votes', function () {

        $('.votes-per-round table').fadeOut();

        //updating vote results
        election.showCandidates();

        if ($(this).attr('data-shown') == "true") {
            $('.current-rankings').fadeOut();
            $(this).attr('data-shown', 'false').html("Show Votes");
        } else {
            $('.current-rankings, .current-rankings table').fadeIn();
            $(this).attr('data-shown', 'true').html("Hide Votes");
        }

        $('.show-votes-round').attr('data-shown', 'false');
    });

    $(document).on('click', '.show-votes-round', function () {

        $('table').fadeOut();

        if ($(this).attr('data-shown') == "true") {

            $('.votes-per-round table').fadeOut();

            $(this).attr('data-shown', "false")

        } else {

            $('.votes-per-round table').fadeIn();

            $(this).attr('data-shown', "true")

        }

        let guid = $('.previous-election.active-election').data('guid');

        if (typeof guid != typeof undefined) {
            election.loadElectionPage(guid);
        }

        //updating vote results
        election.showCandidates();

    });

    // showing the winner if exists
    //election.findWinner();

    /* adding a comment */
    $(document).on("click", '.election-discussion #pushComment', function () {
        if ($('#map-toggle-2d').val() === '3D') {
            $('#map-toggle-2d').trigger("click");
        }
        election.addComment();
    });

    /*  removing self from election */

    $(document).on('click', '#remove-self', function () {

        // removing from candidates page
        election.removeSelf();

        /* removing from voting wrapper */
        $('.vote .vote-item').each(function () {

            if ($(this).attr('data-user') == election.username) {

                $(this).remove();

            }
        });

        $(this).css('display', 'none');

        $('#add-self').html('Run For Office').attr('data-action', 'add');

        /* updating current rankings table */
        if ($('#candidate-names').length != 0) {
            election.setupTable();
        }

        /* recovering the rank values in select menus */

        $('.vote .vote-item select').empty();
        let count = $('.vote .vote-item select').length;

        for (let i = 0; i <= count; i++) {
            $('.vote .vote-item select').append("<option value='" + i + "'> " + i + " </option>");
        }
        location.href = '/elections.html?election=current';
    });

    /* Deactivating rank value that previously used */
    $(document).on('change', '.vote-item select', function () {
        let option = $(this).val();

        /* the case when user changes its rank */
        $(this).find("option").each(function () {
            if ($(this).data('changed') == "yes") {
                let deactivate = $(this).val();
                $('.vote-item select option[value=' + deactivate + ']').removeAttr('disabled');
            }

            if ($(this).val() == option) {
                $(this).attr('data-changed', 'yes');
            }
        });

        $(this).removeAttr('data-value').data('value', option);

        if (option != 0) {
            $('.vote-item select option[value=' + option + ']').attr('disabled', 'disabled');
        }
    });

    //voting
    $(document).on('click', '.vote-button', function() {
        const container = $(this).hasClass('vote-item') ? $(this).parent() : $(this).attr('disabled', 'disabled');

        container.children().fadeOut(400);

        setTimeout(async () => {
            container.append('<span class="localize" translate-key="171">Submitting..</span>');

            try {
                await election.vote();
                container.html('<span class="localize" translate-key="172">Your vote has been counted</span>');

                // 'You have not voted' notification should go away once I vote
                $(`a.running-election[data-guid=${election.electionData.Id}] i.fa`).remove();

                // Refreshing election content w/o reloading the page
                setTimeout(() => {
                    election.loadElectionPage(election.electionData.Id, true);
                }, 1500);
            } catch(e) {
                $(this).removeAttr('disabled');
            }
        }, 500);
    });

    /* Removing graph */
    $(document).on('click', '#removeGraph, .remove-graph-button', function() {
        $(this).hide();
        $('#addGraph').show();
        $('#graph-data').val('');
        $('.comment-graph').slideUp(400, function() {this.remove()});
    });

    $(document).on('click', '.election-process-info', function() {
        election.showElectionProcess(parseInt(getURLParameter("election")));
    });
    // if (election.settings['availableCommentPages'].indexOf(getURLParameter("election")) < 0) {
    //     //	$('.election-comment, .comment-graph, .add-comment-buttons, .edit-comment-buttons').remove();
    // }
}