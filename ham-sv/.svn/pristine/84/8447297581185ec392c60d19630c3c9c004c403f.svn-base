package jp.co.isid.ham.common.model;

import java.io.ByteArrayOutputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

import javax.mail.Authenticator;
import javax.mail.Message;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeUtility;

import jp.co.isid.ham.base.HAMParameter;

public class MailTransport {

    // ************************************************************
    // 定数
    // ************************************************************
    /**
     * 文字コード(件名・本文等のエンコードに使用)
     */
    private static String CHARSET = "iso-2022-jp";

    // ************************************************************
    // メール送信関連
    // ************************************************************
    private Properties _props = null;
    private MimeMessage _msg = null;
    //private Transport _transPort = null;
    private Session _session = null;

    // ************************************************************
    // 送信サーバー関連
    // ************************************************************
    /*
     * SMTPサーバーのアドレス(orサーバー名)
     */
    private String _smtpHost = null;
    /*
     * SMTPサーバーのポート
     */
    private String _smtpPort = null;
    /*
     * SMTPサーバーのログインID
     */
    private String _id = null;
    /*
     * SMTPサーバーのログインパスワード
     */
    private String _password = null;
    /*
     * メール送信時にセッションを接続・切断せずに保持するか
     * (保持する(true)の場合は自分で必ず接続・切断をすること)
     */
    private boolean _sessionMode = false;

    // ************************************************************
    // 送信メール情報
    // ************************************************************
    private String _senderAddress = null;
    private String _senderName = null;
    private String _subject = null;
    private String _message = null;
    private List<InternetAddress> _recipientTo = null;
    private List<InternetAddress> _recipientCc = null;
    private List<InternetAddress> _recipientBcc = null;
    private int _priority = 0;//0:通常, 1:高, 2:低
    private boolean _kaifuFlg = false;


    /**
     * コンストラクタ
     * @param serverName
     * @param id
     * @param password
     * @param sessionMode
     */
    //public MailTransport(String serverName, String id, String password, boolean sessionMode) throws Exception{
    public MailTransport(String id, String password, boolean sessionMode) throws Exception{

        HAMParameter hamParameter = HAMParameter.getInstance();
        _smtpHost = hamParameter.getSmtpHost();//serverName
        _smtpPort = hamParameter.getSmtpPort();
        _id = id;
        _password = password;
        _sessionMode = sessionMode;

        _props = new Properties();
        _props.put("mail.transport.protocol", "smtp");
        _props.put("mail.smtp.host", _smtpHost);
        _props.put("mail.smtp.port", _smtpPort);
        _props.setProperty("mail.smtp.connectiontimeout", "60000");
        _props.setProperty("mail.smtp.timeout", "60000");
        _props.setProperty("mail.smtp.auth", "true");

        _props.setProperty("mail.debug", "true");
    }

    /**
     * 送信者メールアドレスを設定します
     * @param address
     * @throws Exception
     */
    public void setSenderAddress(String address) throws Exception{
        _senderAddress = address;
    }

    /**
     * 送信者名を設定します
     * @param senderName
     */
    public void setSenderName(String senderName) {
        _senderName = senderName;
    }

    /**
     * SMTPサーバーを設定します
     * @param smtp
     */
    public void setSmtpHostName(String smtp) {
        _props.put("mail.smtp.host", smtp);
    }

    /**
     * メッセージの重要度を「高」に設定します
     */
    public void setHighPriority() {
        _priority = 1;
    }

    /**
     * メッセージの重要度を「低」に設定します
     */
    public void setLowPriority() {
        _priority = 2;
    }

    /**
     * メッセージの重要度を「通常」に設定します
     */
    public void setNormalPriority() {
        _priority = 0;
    }

    /**
     * 件名を設定します
     * @param subject
     * @throws Exception
     */
    public void setSubject(String subject) throws Exception{
        //_msg.setSubject(MimeUtility.encodeText(subject, charset, "B"));
        _subject = subject;
    }

    /**
     * 本文を設定します
     * @param message
     */
    public void setMessage(String message) throws Exception{
        _message = message;
    }

    /**
     * 自動折り返しの設定をするかどうかを設定します
     * @param crlfFlg
     */
    public void setCrlfFlg(boolean crlfFlg) {
    }

    /**
     * 自動折り返しを行う際の折り返し位置を設定します
     * @param cols
     */
    public void setCols(int cols) {
    }

    /**
     * 開封確認を行うかどうかを設定します
     * @param kaifuFlg
     */
    public void setKaifuFlg(boolean kaifuFlg) {
        _kaifuFlg = kaifuFlg;
    }

    /**
     * 宛先情報をクリアします
     */
    public void clearRecipientList() {
        if (_recipientTo != null) {
            _recipientTo.clear();
            _recipientTo = null;
        }
        if (_recipientCc != null) {
            _recipientCc.clear();
            _recipientCc = null;
        }
        if (_recipientBcc != null) {
            _recipientBcc.clear();
            _recipientBcc = null;
        }
    }

    /**
     * 宛先情報(TO)を追加します
     * @param toAddress
     * @param toName
     */
    public void addRecipientTo(String toAddress, String toName) throws Exception{
        if (_recipientTo == null) {
            _recipientTo = new ArrayList<InternetAddress>();
        }
        _recipientTo.add(new InternetAddress(toAddress, toName, CHARSET));
    }

    /**
     * 宛先情報(CC)を追加します
     * @param ccAddress
     * @param ccName
     */
    public void addRecipientCc(String ccAddress, String ccName) throws Exception{
        if (_recipientCc == null) {
            _recipientCc = new ArrayList<InternetAddress>();
        }
        _recipientCc.add(new InternetAddress(ccAddress, ccName, CHARSET));
    }

    /**
     * 宛先情報(BCC)を追加します
     * @param bccAddress
     * @param bccName
     */
    public void addRecipientBcc(String bccAddress, String bccName) throws Exception{
        if (_recipientBcc == null) {
            _recipientBcc = new ArrayList<InternetAddress>();
        }
        _recipientBcc.add(new InternetAddress(bccAddress, bccName, CHARSET));
    }

    /**
     * 送信処理を実行します
     */
    public void send() throws Exception{
        if (!_sessionMode) {
            connect();
        }

        try {
            //宛先(To)
            if (_recipientTo != null) {
                _msg.setRecipients(Message.RecipientType.TO, _recipientTo.toArray(new InternetAddress[0]));
            }
            //宛先(Cc)
            if (_recipientCc != null) {
                _msg.setRecipients(Message.RecipientType.CC, _recipientCc.toArray(new InternetAddress[0]));
            }
            //宛先(Bcc)
            if (_recipientBcc != null) {
                _msg.setRecipients(Message.RecipientType.BCC, _recipientBcc.toArray(new InternetAddress[0]));
            }

            //送信者アドレス・名前
            _msg.setFrom(new InternetAddress(_senderAddress, _senderName, CHARSET));

            //件名
            _msg.setSubject(MimeUtility.encodeText(_subject, CHARSET, "B"));

            //本文
//            MimeMultipart content = new MimeMultipart();
//            _msg.setContent(content);
//            MimeBodyPart body = new MimeBodyPart();
//            body.setContent(_message, "text/plain; charset=\"" + CHARSET + "\"");
//            content.addBodyPart(body);
            _msg.setContent( MimeUtility.encodeText( _message , CHARSET , "B" ) , "text/plain; charset=" + CHARSET );
            _msg.setText( _message , CHARSET );


            //重要度
            if (_priority == 1) {
                _msg.addHeader("Importance", "High");
            } else if (_priority == 2) {
                _msg.addHeader("Importance", "Low");
            } else {
                _msg.addHeader("Importance", "Normal");
            }

            //開封確認.
            if (_kaifuFlg) {
                _msg.addHeader("Disposition-Notification-To", _senderAddress);
            }

            Transport.send(_msg);
            //_transPort.sendMessage(_msg, _msg.getRecipients(Message.RecipientType.TO));

        } finally {
            if (!_sessionMode) {
                terminate();
            }
        }
    }

    /**
     * 送信したアイテムを送信済みアイテムに保存します
     */
    public void sentSaveMessage() {
    }

    /**
     * セッションをOPENします
     */
    public void connect() throws Exception{
        _session = Session.getInstance(_props, new esqAuth());
        _msg = new MimeMessage(_session);
        //_transPort = _session.getTransport("smtp");
        //_transPort.connect(_smtpHost, _id, _password);
    }

    /**
     * セッションをCLOSEします
     */
    public void terminate() throws Exception{
//        if (_transPort.isConnected()) {
//            _transPort.close();
//        }
//        _transPort = null;
        _msg = null;
        _session = null;
    }

    //------------------------------------------------------------------------------------------------------------------------
    public static byte[] encrypt(String key, String text) throws Exception {

        javax.crypto.spec.SecretKeySpec sksSpec = new javax.crypto.spec.SecretKeySpec(key.getBytes(), "Blowfish");

        javax.crypto.Cipher cipher = javax.crypto.Cipher.getInstance("Blowfish");
        cipher.init(javax.crypto.Cipher.ENCRYPT_MODE, sksSpec);

        return cipher.doFinal(text.getBytes());
    }

    public static String encodeBase64(byte[] data) throws Exception {

        ByteArrayOutputStream forEncode = new ByteArrayOutputStream();

        OutputStream toBase64 = MimeUtility.encode(forEncode, "base64");
        toBase64.write(data);
        toBase64.close();

        return forEncode.toString("iso-8859-1");
    }

    private class esqAuth extends Authenticator {
        protected PasswordAuthentication getPasswordAuthentication() {
            return new PasswordAuthentication(_id, _password);
        }
    }

}
