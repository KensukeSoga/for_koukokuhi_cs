package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �l��������������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu19NbJkCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ������ƃR�[�h */
    private String _thskgycd = null;

    /** �r�d�p�m�n */
    private String _seqno = null;

    /** ��S���r�d�p�m�n */
    private String _trtntseqno = null;

    /** �l���\���m�n */
    private String _nbiksinseino = null;

    /** ���ϔN�� */
    private String _kesym = null;

    /** �L���I���N���� */
    private String _endymd = null;

    /** �L���J�n�N���� */
    private String _startymd = null;

    /** �\���҃R�[�h */
    private String _snstnt = null;

    /** �K�p�J�n�N���� */
    private String _tysymd = null;

    /** �K�p�I���N���� */
    private String _tyeymd = null;

    /** ���ϓ� */
    private String _kesday = null;

    /** �\���ǃR�[�h */
    private String _snskyk = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu19NbJkCondition() {
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getThskgycd() {
        return _thskgycd;
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param thskgycd ������ƃR�[�h
     */
    public void setThskgycd(String thskgycd) {
        this._thskgycd = thskgycd;
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSeqno() {
        return _seqno;
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param seqno �r�d�p�m�n
     */
    public void setSeqno(String seqno) {
        this._seqno = seqno;
    }

    /**
     * ��S���r�d�p�m�n���擾����
     *
     * @return ��S���r�d�p�m�n
     */
    public String getTrtntseqno() {
        return _trtntseqno;
    }

    /**
     * ��S���r�d�p�m�n��ݒ肷��
     *
     * @param trtntseqno ��S���r�d�p�m�n
     */
    public void setTrtntseqno(String trtntseqno) {
        this._trtntseqno = trtntseqno;
    }

    /**
     * �l���\���m�n���擾����
     *
     * @return �l���\���m�n
     */
    public String getNbiksinseino() {
        return _nbiksinseino;
    }

    /**
     * �l���\���m�n��ݒ肷��
     *
     * @param nbiksinseino �l���\���m�n
     */
    public void setNbiksinseino(String nbiksinseino) {
        this._nbiksinseino = nbiksinseino;
    }

    /**
     * ���ϔN�����擾����
     *
     * @return ���ϔN��
     */
    public String getKesym() {
        return _kesym;
    }

    /**
     * ���ϔN����ݒ肷��
     *
     * @param kesym ���ϔN��
     */
    public void setKesym(String kesym) {
        this._kesym = kesym;
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getEndymd() {
        return _endymd;
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param endymd �L���I���N����
     */
    public void setEndymd(String endymd) {
        this._endymd = endymd;
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getStartymd() {
        return _startymd;
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param startymd �L���J�n�N����
     */
    public void setStartymd(String startymd) {
        this._startymd = startymd;
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSnstnt() {
        return _snstnt;
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param snstnt �\���҃R�[�h
     */
    public void setSnstnt(String snstnt) {
        this._snstnt = snstnt;
    }

    /**
     * �K�p�J�n�N�������擾����
     *
     * @return �K�p�J�n�N����
     */
    public String getTysymd() {
        return _tysymd;
    }

    /**
     * �K�p�J�n�N������ݒ肷��
     *
     * @param tysymd �K�p�J�n�N����
     */
    public void setTysymd(String tysymd) {
        this._tysymd = tysymd;
    }

    /**
     * �K�p�I���N�������擾����
     *
     * @return �K�p�I���N����
     */
    public String getTyeymd() {
        return _tyeymd;
    }

    /**
     * �K�p�I���N������ݒ肷��
     *
     * @param tyeymd �K�p�I���N����
     */
    public void setTyeymd(String tyeymd) {
        this._tyeymd = tyeymd;
    }

    /**
     * ���ϓ����擾����
     *
     * @return ���ϓ�
     */
    public String getKesday() {
        return _kesday;
    }

    /**
     * ���ϓ���ݒ肷��
     *
     * @param kesday ���ϓ�
     */
    public void setKesday(String kesday) {
        this._kesday = kesday;
    }

    /**
     * �\���ǃR�[�h���擾����
     *
     * @return �\���ǃR�[�h
     */
    public String getSnskyk() {
        return _snskyk;
    }

    /**
     * �\���ǃR�[�h��ݒ肷��
     *
     * @param snskyk �\���ǃR�[�h
     */
    public void setSnskyk(String snskyk) {
        this._snskyk = snskyk;
    }

}
