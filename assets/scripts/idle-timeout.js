var IdleTimeout = function () {

    return {

        //sayfa başlangıcı
        init: function () {

            // cache değerini sayaçtan oku
            var $countdown;

            $('body').append('<div class="modal fade" id="idle-timeout-dialog" data-backdrop="static"><div class="modal-dialog modal-small"><div class="modal-content"><div class="modal-header"><h4 class="modal-title">Uzun süredir hareketsizsiniz !!!</h4></div><div class="modal-body"><p><i class="fa fa-warning"></i> Oturumunuz kilitlenecek! <span id="idle-timeout-counter"></span> seconds.</p><p>Çalışmaya devam etmek istiyor musunuz?</p></div><div class="modal-footer"><button id="idle-timeout-dialog-logout" type="button" class="btn btn-default">Hayır, Çıkabilirim</button><button id="idle-timeout-dialog-keepalive" type="button" class="btn btn-primary" data-dismiss="modal">Evet, Çalışıyorum</button></div></div></div></div>');

            // sayaç bilgileri başlıyor
            $.idleTimeout('#idle-timeout-dialog', '.modal-content button:last', {
                idleAfter: 180, // 5 saniye boyunca fareyi oynatmazsa yakala
                timeout: 30000, //30 saniye geri sayım
                pollingInterval: 180, // 5 seconds
                serverResponseEquals: 'OK',
                onTimeout: function () {
                    window.location = "LockScreen.aspx";
                },
                onIdle: function () {
                    $('#idle-timeout-dialog').modal('show');
                    $countdown = $('#idle-timeout-counter');

                    $('#idle-timeout-dialog-keepalive').on('click', function () {
                        $('#idle-timeout-dialog').modal('hide');
                    });

                    $('#idle-timeout-dialog-logout').on('click', function () {
                        $('#idle-timeout-dialog').modal('hide');
                        $.idleTimeout.options.onTimeout.call(this);
                    });
                },
                onCountdown: function (counter) {
                    $countdown.html(counter); // sayacı güncelle
                }
            });

        }

    };

}();