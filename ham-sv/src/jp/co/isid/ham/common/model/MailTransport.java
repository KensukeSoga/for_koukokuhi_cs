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
    // �萔
    // ************************************************************
    /**
     * �����R�[�h(�����E�{�����̃G���R�[�h�Ɏg�p)
     */
    private static String CHARSET = "iso-2022-jp";

    // ************************************************************
    // ���[�����M�֘A
    // ************************************************************
    private Properties _props = null;
    private MimeMessage _msg = null;
    //private Transport _transPort = null;
    private Session _session = null;

    // ************************************************************
    // ���M�T�[�o�[�֘A
    // ************************************************************
    /*
     * SMTP�T�[�o�[�̃A�h���X(or�T�[�o�[��)
     */
    private String _smtpHost = null;
    /*
     * SMTP�T�[�o�[�̃|�[�g
     */
    private String _smtpPort = null;
    /*
     * SMTP�T�[�o�[�̃��O�C��ID
     */
    private String _id = null;
    /*
     * SMTP�T�[�o�[�̃��O�C���p�X���[�h
     */
    private String _password = null;
    /*
     * ���[�����M���ɃZ�b�V������ڑ��E�ؒf�����ɕێ����邩
     * (�ێ�����(true)�̏ꍇ�͎����ŕK���ڑ��E�ؒf�����邱��)
     */
    private boolean _sessionMode = false;

    // ************************************************************
    // ���M���[�����
    // ************************************************************
    private String _senderAddress = null;
    private String _senderName = null;
    private String _subject = null;
    private String _message = null;
    private List<InternetAddress> _recipientTo = null;
    private List<InternetAddress> _recipientCc = null;
    private List<InternetAddress> _recipientBcc = null;
    private int _priority = 0;//0:�ʏ�, 1:��, 2:��
    private boolean _kaifuFlg = false;


    /**
     * �R���X�g���N�^
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
     * ���M�҃��[���A�h���X��ݒ肵�܂�
     * @param address
     * @throws Exception
     */
    public void setSenderAddress(String address) throws Exception{
        _senderAddress = address;
    }

    /**
     * ���M�Җ���ݒ肵�܂�
     * @param senderName
     */
    public void setSenderName(String senderName) {
        _senderName = senderName;
    }

    /**
     * SMTP�T�[�o�[��ݒ肵�܂�
     * @param smtp
     */
    public void setSmtpHostName(String smtp) {
        _props.put("mail.smtp.host", smtp);
    }

    /**
     * ���b�Z�[�W�̏d�v�x���u���v�ɐݒ肵�܂�
     */
    public void setHighPriority() {
        _priority = 1;
    }

    /**
     * ���b�Z�[�W�̏d�v�x���u��v�ɐݒ肵�܂�
     */
    public void setLowPriority() {
        _priority = 2;
    }

    /**
     * ���b�Z�[�W�̏d�v�x���u�ʏ�v�ɐݒ肵�܂�
     */
    public void setNormalPriority() {
        _priority = 0;
    }

    /**
     * ������ݒ肵�܂�
     * @param subject
     * @throws Exception
     */
    public void setSubject(String subject) throws Exception{
        //_msg.setSubject(MimeUtility.encodeText(subject, charset, "B"));
        _subject = subject;
    }

    /**
     * �{����ݒ肵�܂�
     * @param message
     */
    public void setMessage(String message) throws Exception{
        _message = message;
    }

    /**
     * �����܂�Ԃ��̐ݒ�����邩�ǂ�����ݒ肵�܂�
     * @param crlfFlg
     */
    public void setCrlfFlg(boolean crlfFlg) {
    }

    /**
     * �����܂�Ԃ����s���ۂ̐܂�Ԃ��ʒu��ݒ肵�܂�
     * @param cols
     */
    public void setCols(int cols) {
    }

    /**
     * �J���m�F���s�����ǂ�����ݒ肵�܂�
     * @param kaifuFlg
     */
    public void setKaifuFlg(boolean kaifuFlg) {
        _kaifuFlg = kaifuFlg;
    }

    /**
     * ��������N���A���܂�
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
     * ������(TO)��ǉ����܂�
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
     * ������(CC)��ǉ����܂�
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
     * ������(BCC)��ǉ����܂�
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
     * ���M���������s���܂�
     */
    public void send() throws Exception{
        if (!_sessionMode) {
            connect();
        }

        try {
            //����(To)
            if (_recipientTo != null) {
                _msg.setRecipients(Message.RecipientType.TO, _recipientTo.toArray(new InternetAddress[0]));
            }
            //����(Cc)
            if (_recipientCc != null) {
                _msg.setRecipients(Message.RecipientType.CC, _recipientCc.toArray(new InternetAddress[0]));
            }
            //����(Bcc)
            if (_recipientBcc != null) {
                _msg.setRecipients(Message.RecipientType.BCC, _recipientBcc.toArray(new InternetAddress[0]));
            }

            //���M�҃A�h���X�E���O
            _msg.setFrom(new InternetAddress(_senderAddress, _senderName, CHARSET));

            //����
            _msg.setSubject(MimeUtility.encodeText(_subject, CHARSET, "B"));

            //�{��
//            MimeMultipart content = new MimeMultipart();
//            _msg.setContent(content);
//            MimeBodyPart body = new MimeBodyPart();
//            body.setContent(_message, "text/plain; charset=\"" + CHARSET + "\"");
//            content.addBodyPart(body);
            _msg.setContent( MimeUtility.encodeText( _message , CHARSET , "B" ) , "text/plain; charset=" + CHARSET );
            _msg.setText( _message , CHARSET );


            //�d�v�x
            if (_priority == 1) {
                _msg.addHeader("Importance", "High");
            } else if (_priority == 2) {
                _msg.addHeader("Importance", "Low");
            } else {
                _msg.addHeader("Importance", "Normal");
            }

            //�J���m�F.
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
     * ���M�����A�C�e���𑗐M�ς݃A�C�e���ɕۑ����܂�
     */
    public void sentSaveMessage() {
    }

    /**
     * �Z�b�V������OPEN���܂�
     */
    public void connect() throws Exception{
        _session = Session.getInstance(_props, new esqAuth());
        _msg = new MimeMessage(_session);
        //_transPort = _session.getTransport("smtp");
        //_transPort.connect(_smtpHost, _id, _password);
    }

    /**
     * �Z�b�V������CLOSE���܂�
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
