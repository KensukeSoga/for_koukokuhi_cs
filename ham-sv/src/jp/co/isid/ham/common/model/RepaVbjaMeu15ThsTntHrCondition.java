package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �����S���i���j��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu15ThsTntHrCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ������ƃR�[�h */
    private String _thskgycd = null;

    /** �r�d�p�m�n */
    private String _seqno = null;

    /** ���S���r�d�p�m�n */
    private String _hrtntseqno = null;

    /** �L���I���N���� */
    private String _endymd = null;

    /** �L���J�n�N���� */
    private String _startymd = null;

    /** �\���҃R�[�h */
    private String _snstnt = null;

    /** �g�D�R�[�h */
    private String _sikcd = null;

    /** �x����敪 */
    private String _shrkbn = null;

    /** �U����敪 */
    private String _frkskbn = null;

    /** �c�Ɣ�x����敪 */
    private String _eghishrskbn = null;

    /** �ݒ�x����敪 */
    private String _styshrskbn = null;

    /** �\���m�n */
    private String _sinseino = null;

    /** �c�Ə��R�[�h */
    private String _egsyocd = null;

    /** �x�������o�s�m�m�n */
    private String _shjyoknptnno = null;

    /** �������R�[�h */
    private String _kyutrcd = null;

    /** ���S���\�� */
    private String _hrtntyobi = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu15ThsTntHrCondition() {
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
     * ���S���r�d�p�m�n���擾����
     *
     * @return ���S���r�d�p�m�n
     */
    public String getHrtntseqno() {
        return _hrtntseqno;
    }

    /**
     * ���S���r�d�p�m�n��ݒ肷��
     *
     * @param hrtntseqno ���S���r�d�p�m�n
     */
    public void setHrtntseqno(String hrtntseqno) {
        this._hrtntseqno = hrtntseqno;
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
     * �x����敪���擾����
     *
     * @return �x����敪
     */
    public String getShrkbn() {
        return _shrkbn;
    }

    /**
     * �x����敪��ݒ肷��
     *
     * @param shrkbn �x����敪
     */
    public void setShrkbn(String shrkbn) {
        this._shrkbn = shrkbn;
    }

    /**
     * �U����敪���擾����
     *
     * @return �U����敪
     */
    public String getFrkskbn() {
        return _frkskbn;
    }

    /**
     * �U����敪��ݒ肷��
     *
     * @param frkskbn �U����敪
     */
    public void setFrkskbn(String frkskbn) {
        this._frkskbn = frkskbn;
    }

    /**
     * �c�Ɣ�x����敪���擾����
     *
     * @return �c�Ɣ�x����敪
     */
    public String getEghishrskbn() {
        return _eghishrskbn;
    }

    /**
     * �c�Ɣ�x����敪��ݒ肷��
     *
     * @param eghishrskbn �c�Ɣ�x����敪
     */
    public void setEghishrskbn(String eghishrskbn) {
        this._eghishrskbn = eghishrskbn;
    }

    /**
     * �ݒ�x����敪���擾����
     *
     * @return �ݒ�x����敪
     */
    public String getStyshrskbn() {
        return _styshrskbn;
    }

    /**
     * �ݒ�x����敪��ݒ肷��
     *
     * @param styshrskbn �ݒ�x����敪
     */
    public void setStyshrskbn(String styshrskbn) {
        this._styshrskbn = styshrskbn;
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
     * �x�������o�s�m�m�n���擾����
     *
     * @return �x�������o�s�m�m�n
     */
    public String getShjyoknptnno() {
        return _shjyoknptnno;
    }

    /**
     * �x�������o�s�m�m�n��ݒ肷��
     *
     * @param shjyoknptnno �x�������o�s�m�m�n
     */
    public void setShjyoknptnno(String shjyoknptnno) {
        this._shjyoknptnno = shjyoknptnno;
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
     * ���S���\�����擾����
     *
     * @return ���S���\��
     */
    public String getHrtntyobi() {
        return _hrtntyobi;
    }

    /**
     * ���S���\����ݒ肷��
     *
     * @param hrtntyobi ���S���\��
     */
    public void setHrtntyobi(String hrtntyobi) {
        this._hrtntyobi = hrtntyobi;
    }

}
