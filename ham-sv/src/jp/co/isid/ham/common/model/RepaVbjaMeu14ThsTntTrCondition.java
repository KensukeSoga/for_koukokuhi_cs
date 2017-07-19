package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �����S���i��j��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu14ThsTntTrCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ������ƃR�[�h */
    private String _thskgycd = null;

    /** �r�d�p�m�n */
    private String _seqno = null;

    /** ��S���r�d�p�m�n */
    private String _trtntseqno = null;

    /** �L���I���N���� */
    private String _endymd = null;

    /** �L���J�n�N���� */
    private String _startymd = null;

    /** �\���҃R�[�h */
    private String _snstnt = null;

    /** �g�D�R�[�h */
    private String _sikcd = null;

    /** �L����敪 */
    private String _clntkbn = null;

    /** ���Ӑ�敪 */
    private String _tkkbn = null;

    /** ������敪 */
    private String _skyuskbn = null;

    /** ������敪 */
    private String _nkinskbn = null;

    /** �������Ӑ�敪 */
    private String _mkmtkskbn = null;

    /** �c�Ɣ�Ӑ�敪 */
    private String _eghishrskbn = null;

    /** �\���m�n */
    private String _sinseino = null;

    /** �c�Ə��R�[�h */
    private String _egsyocd = null;

    /** �L�����ƃR�[�h */
    private String _clntkgycd = null;

    /** �L����r�d�p�m�n */
    private String _clntseqno = null;

    /** �������R�[�h */
    private String _kyutrcd = null;

    /** ��S���\�� */
    private String _trtntyobi = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu14ThsTntTrCondition() {
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
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getSikcd() {
        return _sikcd;
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param sikcd �g�D�R�[�h
     */
    public void setSikcd(String sikcd) {
        this._sikcd = sikcd;
    }

    /**
     * �L����敪���擾����
     *
     * @return �L����敪
     */
    public String getClntkbn() {
        return _clntkbn;
    }

    /**
     * �L����敪��ݒ肷��
     *
     * @param clntkbn �L����敪
     */
    public void setClntkbn(String clntkbn) {
        this._clntkbn = clntkbn;
    }

    /**
     * ���Ӑ�敪���擾����
     *
     * @return ���Ӑ�敪
     */
    public String getTkkbn() {
        return _tkkbn;
    }

    /**
     * ���Ӑ�敪��ݒ肷��
     *
     * @param tkkbn ���Ӑ�敪
     */
    public void setTkkbn(String tkkbn) {
        this._tkkbn = tkkbn;
    }

    /**
     * ������敪���擾����
     *
     * @return ������敪
     */
    public String getSkyuskbn() {
        return _skyuskbn;
    }

    /**
     * ������敪��ݒ肷��
     *
     * @param skyuskbn ������敪
     */
    public void setSkyuskbn(String skyuskbn) {
        this._skyuskbn = skyuskbn;
    }

    /**
     * ������敪���擾����
     *
     * @return ������敪
     */
    public String getNkinskbn() {
        return _nkinskbn;
    }

    /**
     * ������敪��ݒ肷��
     *
     * @param nkinskbn ������敪
     */
    public void setNkinskbn(String nkinskbn) {
        this._nkinskbn = nkinskbn;
    }

    /**
     * �������Ӑ�敪���擾����
     *
     * @return �������Ӑ�敪
     */
    public String getMkmtkskbn() {
        return _mkmtkskbn;
    }

    /**
     * �������Ӑ�敪��ݒ肷��
     *
     * @param mkmtkskbn �������Ӑ�敪
     */
    public void setMkmtkskbn(String mkmtkskbn) {
        this._mkmtkskbn = mkmtkskbn;
    }

    /**
     * �c�Ɣ�Ӑ�敪���擾����
     *
     * @return �c�Ɣ�Ӑ�敪
     */
    public String getEghishrskbn() {
        return _eghishrskbn;
    }

    /**
     * �c�Ɣ�Ӑ�敪��ݒ肷��
     *
     * @param eghishrskbn �c�Ɣ�Ӑ�敪
     */
    public void setEghishrskbn(String eghishrskbn) {
        this._eghishrskbn = eghishrskbn;
    }

    /**
     * �\���m�n���擾����
     *
     * @return �\���m�n
     */
    public String getSinseino() {
        return _sinseino;
    }

    /**
     * �\���m�n��ݒ肷��
     *
     * @param sinseino �\���m�n
     */
    public void setSinseino(String sinseino) {
        this._sinseino = sinseino;
    }

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return �c�Ə��R�[�h
     */
    public String getEgsyocd() {
        return _egsyocd;
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     *
     * @param egsyocd �c�Ə��R�[�h
     */
    public void setEgsyocd(String egsyocd) {
        this._egsyocd = egsyocd;
    }

    /**
     * �L�����ƃR�[�h���擾����
     *
     * @return �L�����ƃR�[�h
     */
    public String getClntkgycd() {
        return _clntkgycd;
    }

    /**
     * �L�����ƃR�[�h��ݒ肷��
     *
     * @param clntkgycd �L�����ƃR�[�h
     */
    public void setClntkgycd(String clntkgycd) {
        this._clntkgycd = clntkgycd;
    }

    /**
     * �L����r�d�p�m�n���擾����
     *
     * @return �L����r�d�p�m�n
     */
    public String getClntseqno() {
        return _clntseqno;
    }

    /**
     * �L����r�d�p�m�n��ݒ肷��
     *
     * @param clntseqno �L����r�d�p�m�n
     */
    public void setClntseqno(String clntseqno) {
        this._clntseqno = clntseqno;
    }

    /**
     * �������R�[�h���擾����
     *
     * @return �������R�[�h
     */
    public String getKyutrcd() {
        return _kyutrcd;
    }

    /**
     * �������R�[�h��ݒ肷��
     *
     * @param kyutrcd �������R�[�h
     */
    public void setKyutrcd(String kyutrcd) {
        this._kyutrcd = kyutrcd;
    }

    /**
     * ��S���\�����擾����
     *
     * @return ��S���\��
     */
    public String getTrtntyobi() {
        return _trtntyobi;
    }

    /**
     * ��S���\����ݒ肷��
     *
     * @param trtntyobi ��S���\��
     */
    public void setTrtntyobi(String trtntyobi) {
        this._trtntyobi = trtntyobi;
    }

}
