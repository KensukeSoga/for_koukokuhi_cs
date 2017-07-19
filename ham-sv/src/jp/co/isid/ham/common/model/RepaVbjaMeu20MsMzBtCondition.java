package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �V�G�}�̃}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu20MsMzBtCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �V�G�敪 */
    private String _szkbn = null;

    /** �V�G�}�̃R�[�h */
    private String _sinzatsubtaicd = null;

    /** ���ŃR�[�h */
    private String _kbancd = null;

    /** �V�G�}�̖��i�����j */
    private String _sinzatsubtainmj = null;

    /** �V�G�}�̖��i�J�i�j */
    private String _sinzatsubtainmk = null;

    /** �}�̎Њ�ƃR�[�h */
    private String _btaisyakcd = null;

    /** �}�̎Ђr�d�p�m�n */
    private String _btaisyaseqno = null;

    /** �������R�[�h */
    private String _kyutrcd = null;

    /** �N�[�N���� */
    private String _khyoymd = null;

    /** �W�������i�P�j */
    private String _janr1 = null;

    /** �W�������i�Q�j */
    private String _janr2 = null;

    /** �W�������i�R�j */
    private String _janr3 = null;

    /** �����n�����敪 */
    private String _chuchikbn = null;

    /** �V���荆�R�[�h */
    private String _sinbundaigocd = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu20MsMzBtCondition() {
    }

    /**
     * �V�G�敪���擾����
     *
     * @return �V�G�敪
     */
    public String getSzkbn() {
        return _szkbn;
    }

    /**
     * �V�G�敪��ݒ肷��
     *
     * @param szkbn �V�G�敪
     */
    public void setSzkbn(String szkbn) {
        this._szkbn = szkbn;
    }

    /**
     * �V�G�}�̃R�[�h���擾����
     *
     * @return �V�G�}�̃R�[�h
     */
    public String getSinzatsubtaicd() {
        return _sinzatsubtaicd;
    }

    /**
     * �V�G�}�̃R�[�h��ݒ肷��
     *
     * @param sinzatsubtaicd �V�G�}�̃R�[�h
     */
    public void setSinzatsubtaicd(String sinzatsubtaicd) {
        this._sinzatsubtaicd = sinzatsubtaicd;
    }

    /**
     * ���ŃR�[�h���擾����
     *
     * @return ���ŃR�[�h
     */
    public String getKbancd() {
        return _kbancd;
    }

    /**
     * ���ŃR�[�h��ݒ肷��
     *
     * @param kbancd ���ŃR�[�h
     */
    public void setKbancd(String kbancd) {
        this._kbancd = kbancd;
    }

    /**
     * �V�G�}�̖��i�����j���擾����
     *
     * @return �V�G�}�̖��i�����j
     */
    public String getSinzatsubtainmj() {
        return _sinzatsubtainmj;
    }

    /**
     * �V�G�}�̖��i�����j��ݒ肷��
     *
     * @param sinzatsubtainmj �V�G�}�̖��i�����j
     */
    public void setSinzatsubtainmj(String sinzatsubtainmj) {
        this._sinzatsubtainmj = sinzatsubtainmj;
    }

    /**
     * �V�G�}�̖��i�J�i�j���擾����
     *
     * @return �V�G�}�̖��i�J�i�j
     */
    public String getSinzatsubtainmk() {
        return _sinzatsubtainmk;
    }

    /**
     * �V�G�}�̖��i�J�i�j��ݒ肷��
     *
     * @param sinzatsubtainmk �V�G�}�̖��i�J�i�j
     */
    public void setSinzatsubtainmk(String sinzatsubtainmk) {
        this._sinzatsubtainmk = sinzatsubtainmk;
    }

    /**
     * �}�̎Њ�ƃR�[�h���擾����
     *
     * @return �}�̎Њ�ƃR�[�h
     */
    public String getBtaisyakcd() {
        return _btaisyakcd;
    }

    /**
     * �}�̎Њ�ƃR�[�h��ݒ肷��
     *
     * @param btaisyakcd �}�̎Њ�ƃR�[�h
     */
    public void setBtaisyakcd(String btaisyakcd) {
        this._btaisyakcd = btaisyakcd;
    }

    /**
     * �}�̎Ђr�d�p�m�n���擾����
     *
     * @return �}�̎Ђr�d�p�m�n
     */
    public String getBtaisyaseqno() {
        return _btaisyaseqno;
    }

    /**
     * �}�̎Ђr�d�p�m�n��ݒ肷��
     *
     * @param btaisyaseqno �}�̎Ђr�d�p�m�n
     */
    public void setBtaisyaseqno(String btaisyaseqno) {
        this._btaisyaseqno = btaisyaseqno;
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
     * �N�[�N�������擾����
     *
     * @return �N�[�N����
     */
    public String getKhyoymd() {
        return _khyoymd;
    }

    /**
     * �N�[�N������ݒ肷��
     *
     * @param khyoymd �N�[�N����
     */
    public void setKhyoymd(String khyoymd) {
        this._khyoymd = khyoymd;
    }

    /**
     * �W�������i�P�j���擾����
     *
     * @return �W�������i�P�j
     */
    public String getJanr1() {
        return _janr1;
    }

    /**
     * �W�������i�P�j��ݒ肷��
     *
     * @param janr1 �W�������i�P�j
     */
    public void setJanr1(String janr1) {
        this._janr1 = janr1;
    }

    /**
     * �W�������i�Q�j���擾����
     *
     * @return �W�������i�Q�j
     */
    public String getJanr2() {
        return _janr2;
    }

    /**
     * �W�������i�Q�j��ݒ肷��
     *
     * @param janr2 �W�������i�Q�j
     */
    public void setJanr2(String janr2) {
        this._janr2 = janr2;
    }

    /**
     * �W�������i�R�j���擾����
     *
     * @return �W�������i�R�j
     */
    public String getJanr3() {
        return _janr3;
    }

    /**
     * �W�������i�R�j��ݒ肷��
     *
     * @param janr3 �W�������i�R�j
     */
    public void setJanr3(String janr3) {
        this._janr3 = janr3;
    }

    /**
     * �����n�����敪���擾����
     *
     * @return �����n�����敪
     */
    public String getChuchikbn() {
        return _chuchikbn;
    }

    /**
     * �����n�����敪��ݒ肷��
     *
     * @param chuchikbn �����n�����敪
     */
    public void setChuchikbn(String chuchikbn) {
        this._chuchikbn = chuchikbn;
    }

    /**
     * �V���荆�R�[�h���擾����
     *
     * @return �V���荆�R�[�h
     */
    public String getSinbundaigocd() {
        return _sinbundaigocd;
    }

    /**
     * �V���荆�R�[�h��ݒ肷��
     *
     * @param sinbundaigocd �V���荆�R�[�h
     */
    public void setSinbundaigocd(String sinbundaigocd) {
        this._sinbundaigocd = sinbundaigocd;
    }

}
