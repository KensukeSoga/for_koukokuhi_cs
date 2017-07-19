package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���J�͈̓}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mfk01KkhCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �^�C���X�^���v */
    private Date _timstmp = null;

    /** �X�V�v���O���� */
    private String _updapl = null;

    /** �X�V�S���� */
    private String _updtnt = null;

    /** ���j�b�gNo. */
    private String _zsbch0100 = null;

    /** �L���I���� */
    private String _dateto = null;

    /** �L���J�n�� */
    private String _datefrom = null;

    /** �g�D�R�[�h */
    private String _zsbch0105 = null;

    /** �͈̓t���O */
    private String _zhannigf = null;

    /** �S���O���[�v */
    private String _zsbch0109 = null;

    /** �E�ʁE�����O���[�v */
    private String _ztoukyu = null;

    /** �Ј��R�[�h */
    private String _zsbch0110 = null;

    /** �\�Z�Ȗځi�啪�ށj */
    private String _zbacctl = null;

    /** �\�Z�Ȗ�(�����ށj */
    private String _zbacctm = null;

    /** �\�Z�Ȗ�(�����ށj */
    private String _zbaccts = null;

    /** �c�Ɣ�o�^�t���O */
    private String _zeigyou = null;

    /** �s�q�r�o�^�t���O */
    private String _ztrsfg = null;

    /** PL�Ɖ�t���O */
    private String _zplfg = null;

    /** �󔭒��o�^�t���O */
    private String _zjyuhachu = null;

    /** �S�����t���O */
    private String _zallfg = null;

    /** �p���Ǘ��t���O */
    private String _zkeisyou = null;

    /** �_���폜�t���O */
    private String _zdelfg = null;

    /** ���J�͈̓^�C���X�^���v */
    private String _kkhtimestamp = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mfk01KkhCondition() {
    }

    /**
     * �^�C���X�^���v���擾����
     *
     * @return �^�C���X�^���v
     */
    @XmlElement(required = true, nillable = true)
    public Date getTimstmp() {
        return _timstmp;
    }

    /**
     * �^�C���X�^���v��ݒ肷��
     *
     * @param timstmp �^�C���X�^���v
     */
    public void setTimstmp(Date timstmp) {
        this._timstmp = timstmp;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param updapl �X�V�v���O����
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * �X�V�S���҂��擾����
     *
     * @return �X�V�S����
     */
    public String getUpdtnt() {
        return _updtnt;
    }

    /**
     * �X�V�S���҂�ݒ肷��
     *
     * @param updtnt �X�V�S����
     */
    public void setUpdtnt(String updtnt) {
        this._updtnt = updtnt;
    }

    /**
     * ���j�b�gNo.���擾����
     *
     * @return ���j�b�gNo.
     */
    public String getZsbch0100() {
        return _zsbch0100;
    }

    /**
     * ���j�b�gNo.��ݒ肷��
     *
     * @param zsbch0100 ���j�b�gNo.
     */
    public void setZsbch0100(String zsbch0100) {
        this._zsbch0100 = zsbch0100;
    }

    /**
     * �L���I�������擾����
     *
     * @return �L���I����
     */
    public String getDateto() {
        return _dateto;
    }

    /**
     * �L���I������ݒ肷��
     *
     * @param dateto �L���I����
     */
    public void setDateto(String dateto) {
        this._dateto = dateto;
    }

    /**
     * �L���J�n�����擾����
     *
     * @return �L���J�n��
     */
    public String getDatefrom() {
        return _datefrom;
    }

    /**
     * �L���J�n����ݒ肷��
     *
     * @param datefrom �L���J�n��
     */
    public void setDatefrom(String datefrom) {
        this._datefrom = datefrom;
    }

    /**
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getZsbch0105() {
        return _zsbch0105;
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param zsbch0105 �g�D�R�[�h
     */
    public void setZsbch0105(String zsbch0105) {
        this._zsbch0105 = zsbch0105;
    }

    /**
     * �͈̓t���O���擾����
     *
     * @return �͈̓t���O
     */
    public String getZhannigf() {
        return _zhannigf;
    }

    /**
     * �͈̓t���O��ݒ肷��
     *
     * @param zhannigf �͈̓t���O
     */
    public void setZhannigf(String zhannigf) {
        this._zhannigf = zhannigf;
    }

    /**
     * �S���O���[�v���擾����
     *
     * @return �S���O���[�v
     */
    public String getZsbch0109() {
        return _zsbch0109;
    }

    /**
     * �S���O���[�v��ݒ肷��
     *
     * @param zsbch0109 �S���O���[�v
     */
    public void setZsbch0109(String zsbch0109) {
        this._zsbch0109 = zsbch0109;
    }

    /**
     * �E�ʁE�����O���[�v���擾����
     *
     * @return �E�ʁE�����O���[�v
     */
    public String getZtoukyu() {
        return _ztoukyu;
    }

    /**
     * �E�ʁE�����O���[�v��ݒ肷��
     *
     * @param ztoukyu �E�ʁE�����O���[�v
     */
    public void setZtoukyu(String ztoukyu) {
        this._ztoukyu = ztoukyu;
    }

    /**
     * �Ј��R�[�h���擾����
     *
     * @return �Ј��R�[�h
     */
    public String getZsbch0110() {
        return _zsbch0110;
    }

    /**
     * �Ј��R�[�h��ݒ肷��
     *
     * @param zsbch0110 �Ј��R�[�h
     */
    public void setZsbch0110(String zsbch0110) {
        this._zsbch0110 = zsbch0110;
    }

    /**
     * �\�Z�Ȗځi�啪�ށj���擾����
     *
     * @return �\�Z�Ȗځi�啪�ށj
     */
    public String getZbacctl() {
        return _zbacctl;
    }

    /**
     * �\�Z�Ȗځi�啪�ށj��ݒ肷��
     *
     * @param zbacctl �\�Z�Ȗځi�啪�ށj
     */
    public void setZbacctl(String zbacctl) {
        this._zbacctl = zbacctl;
    }

    /**
     * �\�Z�Ȗ�(�����ށj���擾����
     *
     * @return �\�Z�Ȗ�(�����ށj
     */
    public String getZbacctm() {
        return _zbacctm;
    }

    /**
     * �\�Z�Ȗ�(�����ށj��ݒ肷��
     *
     * @param zbacctm �\�Z�Ȗ�(�����ށj
     */
    public void setZbacctm(String zbacctm) {
        this._zbacctm = zbacctm;
    }

    /**
     * �\�Z�Ȗ�(�����ށj���擾����
     *
     * @return �\�Z�Ȗ�(�����ށj
     */
    public String getZbaccts() {
        return _zbaccts;
    }

    /**
     * �\�Z�Ȗ�(�����ށj��ݒ肷��
     *
     * @param zbaccts �\�Z�Ȗ�(�����ށj
     */
    public void setZbaccts(String zbaccts) {
        this._zbaccts = zbaccts;
    }

    /**
     * �c�Ɣ�o�^�t���O���擾����
     *
     * @return �c�Ɣ�o�^�t���O
     */
    public String getZeigyou() {
        return _zeigyou;
    }

    /**
     * �c�Ɣ�o�^�t���O��ݒ肷��
     *
     * @param zeigyou �c�Ɣ�o�^�t���O
     */
    public void setZeigyou(String zeigyou) {
        this._zeigyou = zeigyou;
    }

    /**
     * �s�q�r�o�^�t���O���擾����
     *
     * @return �s�q�r�o�^�t���O
     */
    public String getZtrsfg() {
        return _ztrsfg;
    }

    /**
     * �s�q�r�o�^�t���O��ݒ肷��
     *
     * @param ztrsfg �s�q�r�o�^�t���O
     */
    public void setZtrsfg(String ztrsfg) {
        this._ztrsfg = ztrsfg;
    }

    /**
     * PL�Ɖ�t���O���擾����
     *
     * @return PL�Ɖ�t���O
     */
    public String getZplfg() {
        return _zplfg;
    }

    /**
     * PL�Ɖ�t���O��ݒ肷��
     *
     * @param zplfg PL�Ɖ�t���O
     */
    public void setZplfg(String zplfg) {
        this._zplfg = zplfg;
    }

    /**
     * �󔭒��o�^�t���O���擾����
     *
     * @return �󔭒��o�^�t���O
     */
    public String getZjyuhachu() {
        return _zjyuhachu;
    }

    /**
     * �󔭒��o�^�t���O��ݒ肷��
     *
     * @param zjyuhachu �󔭒��o�^�t���O
     */
    public void setZjyuhachu(String zjyuhachu) {
        this._zjyuhachu = zjyuhachu;
    }

    /**
     * �S�����t���O���擾����
     *
     * @return �S�����t���O
     */
    public String getZallfg() {
        return _zallfg;
    }

    /**
     * �S�����t���O��ݒ肷��
     *
     * @param zallfg �S�����t���O
     */
    public void setZallfg(String zallfg) {
        this._zallfg = zallfg;
    }

    /**
     * �p���Ǘ��t���O���擾����
     *
     * @return �p���Ǘ��t���O
     */
    public String getZkeisyou() {
        return _zkeisyou;
    }

    /**
     * �p���Ǘ��t���O��ݒ肷��
     *
     * @param zkeisyou �p���Ǘ��t���O
     */
    public void setZkeisyou(String zkeisyou) {
        this._zkeisyou = zkeisyou;
    }

    /**
     * �_���폜�t���O���擾����
     *
     * @return �_���폜�t���O
     */
    public String getZdelfg() {
        return _zdelfg;
    }

    /**
     * �_���폜�t���O��ݒ肷��
     *
     * @param zdelfg �_���폜�t���O
     */
    public void setZdelfg(String zdelfg) {
        this._zdelfg = zdelfg;
    }

    /**
     * ���J�͈̓^�C���X�^���v���擾����
     *
     * @return ���J�͈̓^�C���X�^���v
     */
    public String getKkhtimestamp() {
        return _kkhtimestamp;
    }

    /**
     * ���J�͈̓^�C���X�^���v��ݒ肷��
     *
     * @param kkhtimestamp ���J�͈̓^�C���X�^���v
     */
    public void setKkhtimestamp(String kkhtimestamp) {
        this._kkhtimestamp = kkhtimestamp;
    }

}
