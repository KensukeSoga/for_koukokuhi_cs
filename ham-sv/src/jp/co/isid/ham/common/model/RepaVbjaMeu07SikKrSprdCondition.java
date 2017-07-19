package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �o���g�D�W�J�e�[�u����������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu07SikKrSprdCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �g�D�R�[�h */
    private String _sikcd = null;

    /** �L���I���N���� */
    private String _endymd = null;

    /** �L���J�n�N���� */
    private String _startymd = null;

    /** �o���K�w�R�[�h */
    private String _krikaisocd = null;

    /** �o����ʑg�D�R�[�h */
    private String _krijsikcd = null;

    /** �����敪 */
    private String _ckatukbn = null;

    /** �󒍓o�^�敪 */
    private String _jytrkkbn = null;

    /** �����o�^�敪 */
    private String _odrtrkkbn = null;

    /** �Ǘ����� */
    private String _knribmon = null;

    /** ��Ў����R�[�h */
    private String _kshathscd = null;

    /** ��Ў����r�d�p�m�n */
    private String _kshathsseqno = null;

    /** �������R�[�h */
    private String _kyutrcd = null;

    /** �}���敪 */
    private String _bckkbn = null;

    /** �c�Ə��R�[�h */
    private String _egsyocd = null;

    /** �\���� */
    private String _showno = null;

    /** ��ʑg�D���\���� */
    private String _jsikhyojijun = null;

    /** �\�����i�J�i�j */
    private String _hyojikn = null;

    /** �\�����i�����j */
    private String _hyojikj = null;

    /** �\������ */
    private String _hyojiryaku = null;

    /** �\�����i�p���j */
    private String _hyojien = null;

    /** ��Ў��ʃR�[�h */
    private String _kshaskbtucd = null;

    /** ���o�̓R�[�h */
    private String _iocd = null;

    /** ����p�r�R�[�h */
    private String _spusecd = null;

    /** �g�D�R�[�h�i�{���j */
    private String _sikcdhonb = null;

    /** �{���\�����i�J�i�j */
    private String _honbhyojikn = null;

    /** �{���\�����i�����j */
    private String _honbhyojikj = null;

    /** �{���\������ */
    private String _honbhyojiryaku = null;

    /** �{���\�����i�p���j */
    private String _honbhyojien = null;

    /** �g�D�R�[�h�i�ǁj */
    private String _sikcdkyk = null;

    /** �Ǖ\�����i�J�i�j */
    private String _kykhyojikn = null;

    /** �Ǖ\�����i�����j */
    private String _kykhyojikj = null;

    /** �Ǖ\������ */
    private String _kykhyojiryaku = null;

    /** �Ǖ\�����i�p���j */
    private String _kykhyojien = null;

    /** �g�D�R�[�h�i���j */
    private String _sikcdsitu = null;

    /** ���\�����i�J�i�j */
    private String _situhyojikn = null;

    /** ���\�����i�����j */
    private String _situhyojikj = null;

    /** ���\������ */
    private String _situhyojiryaku = null;

    /** ���\�����i�p���j */
    private String _situhyojien = null;

    /** �g�D�R�[�h�i���j */
    private String _sikcdbu = null;

    /** ���\�����i�J�i�j */
    private String _buhyojikn = null;

    /** ���\�����i�����j */
    private String _buhyojikj = null;

    /** ���\������ */
    private String _buhyojiryaku = null;

    /** ���\�����i�p���j */
    private String _buhyojien = null;

    /** �g�D�R�[�h�i�ہj */
    private String _sikcdka = null;

    /** �ە\�����i�J�i�j */
    private String _kahyojikn = null;

    /** �ە\�����i�����j */
    private String _kahyojikj = null;

    /** �ە\������ */
    private String _kahyojiryaku = null;

    /** �ە\�����i�p���j */
    private String _kahyojien = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu07SikKrSprdCondition() {
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
     * �o���K�w�R�[�h���擾����
     *
     * @return �o���K�w�R�[�h
     */
    public String getKrikaisocd() {
        return _krikaisocd;
    }

    /**
     * �o���K�w�R�[�h��ݒ肷��
     *
     * @param krikaisocd �o���K�w�R�[�h
     */
    public void setKrikaisocd(String krikaisocd) {
        this._krikaisocd = krikaisocd;
    }

    /**
     * �o����ʑg�D�R�[�h���擾����
     *
     * @return �o����ʑg�D�R�[�h
     */
    public String getKrijsikcd() {
        return _krijsikcd;
    }

    /**
     * �o����ʑg�D�R�[�h��ݒ肷��
     *
     * @param krijsikcd �o����ʑg�D�R�[�h
     */
    public void setKrijsikcd(String krijsikcd) {
        this._krijsikcd = krijsikcd;
    }

    /**
     * �����敪���擾����
     *
     * @return �����敪
     */
    public String getCkatukbn() {
        return _ckatukbn;
    }

    /**
     * �����敪��ݒ肷��
     *
     * @param ckatukbn �����敪
     */
    public void setCkatukbn(String ckatukbn) {
        this._ckatukbn = ckatukbn;
    }

    /**
     * �󒍓o�^�敪���擾����
     *
     * @return �󒍓o�^�敪
     */
    public String getJytrkkbn() {
        return _jytrkkbn;
    }

    /**
     * �󒍓o�^�敪��ݒ肷��
     *
     * @param jytrkkbn �󒍓o�^�敪
     */
    public void setJytrkkbn(String jytrkkbn) {
        this._jytrkkbn = jytrkkbn;
    }

    /**
     * �����o�^�敪���擾����
     *
     * @return �����o�^�敪
     */
    public String getOdrtrkkbn() {
        return _odrtrkkbn;
    }

    /**
     * �����o�^�敪��ݒ肷��
     *
     * @param odrtrkkbn �����o�^�敪
     */
    public void setOdrtrkkbn(String odrtrkkbn) {
        this._odrtrkkbn = odrtrkkbn;
    }

    /**
     * �Ǘ�������擾����
     *
     * @return �Ǘ�����
     */
    public String getKnribmon() {
        return _knribmon;
    }

    /**
     * �Ǘ������ݒ肷��
     *
     * @param knribmon �Ǘ�����
     */
    public void setKnribmon(String knribmon) {
        this._knribmon = knribmon;
    }

    /**
     * ��Ў����R�[�h���擾����
     *
     * @return ��Ў����R�[�h
     */
    public String getKshathscd() {
        return _kshathscd;
    }

    /**
     * ��Ў����R�[�h��ݒ肷��
     *
     * @param kshathscd ��Ў����R�[�h
     */
    public void setKshathscd(String kshathscd) {
        this._kshathscd = kshathscd;
    }

    /**
     * ��Ў����r�d�p�m�n���擾����
     *
     * @return ��Ў����r�d�p�m�n
     */
    public String getKshathsseqno() {
        return _kshathsseqno;
    }

    /**
     * ��Ў����r�d�p�m�n��ݒ肷��
     *
     * @param kshathsseqno ��Ў����r�d�p�m�n
     */
    public void setKshathsseqno(String kshathsseqno) {
        this._kshathsseqno = kshathsseqno;
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
     * �}���敪���擾����
     *
     * @return �}���敪
     */
    public String getBckkbn() {
        return _bckkbn;
    }

    /**
     * �}���敪��ݒ肷��
     *
     * @param bckkbn �}���敪
     */
    public void setBckkbn(String bckkbn) {
        this._bckkbn = bckkbn;
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
     * �\�������擾����
     *
     * @return �\����
     */
    public String getShowno() {
        return _showno;
    }

    /**
     * �\������ݒ肷��
     *
     * @param showno �\����
     */
    public void setShowno(String showno) {
        this._showno = showno;
    }

    /**
     * ��ʑg�D���\�������擾����
     *
     * @return ��ʑg�D���\����
     */
    public String getJsikhyojijun() {
        return _jsikhyojijun;
    }

    /**
     * ��ʑg�D���\������ݒ肷��
     *
     * @param jsikhyojijun ��ʑg�D���\����
     */
    public void setJsikhyojijun(String jsikhyojijun) {
        this._jsikhyojijun = jsikhyojijun;
    }

    /**
     * �\�����i�J�i�j���擾����
     *
     * @return �\�����i�J�i�j
     */
    public String getHyojikn() {
        return _hyojikn;
    }

    /**
     * �\�����i�J�i�j��ݒ肷��
     *
     * @param hyojikn �\�����i�J�i�j
     */
    public void setHyojikn(String hyojikn) {
        this._hyojikn = hyojikn;
    }

    /**
     * �\�����i�����j���擾����
     *
     * @return �\�����i�����j
     */
    public String getHyojikj() {
        return _hyojikj;
    }

    /**
     * �\�����i�����j��ݒ肷��
     *
     * @param hyojikj �\�����i�����j
     */
    public void setHyojikj(String hyojikj) {
        this._hyojikj = hyojikj;
    }

    /**
     * �\�����̂��擾����
     *
     * @return �\������
     */
    public String getHyojiryaku() {
        return _hyojiryaku;
    }

    /**
     * �\�����̂�ݒ肷��
     *
     * @param hyojiryaku �\������
     */
    public void setHyojiryaku(String hyojiryaku) {
        this._hyojiryaku = hyojiryaku;
    }

    /**
     * �\�����i�p���j���擾����
     *
     * @return �\�����i�p���j
     */
    public String getHyojien() {
        return _hyojien;
    }

    /**
     * �\�����i�p���j��ݒ肷��
     *
     * @param hyojien �\�����i�p���j
     */
    public void setHyojien(String hyojien) {
        this._hyojien = hyojien;
    }

    /**
     * ��Ў��ʃR�[�h���擾����
     *
     * @return ��Ў��ʃR�[�h
     */
    public String getKshaskbtucd() {
        return _kshaskbtucd;
    }

    /**
     * ��Ў��ʃR�[�h��ݒ肷��
     *
     * @param kshaskbtucd ��Ў��ʃR�[�h
     */
    public void setKshaskbtucd(String kshaskbtucd) {
        this._kshaskbtucd = kshaskbtucd;
    }

    /**
     * ���o�̓R�[�h���擾����
     *
     * @return ���o�̓R�[�h
     */
    public String getIocd() {
        return _iocd;
    }

    /**
     * ���o�̓R�[�h��ݒ肷��
     *
     * @param iocd ���o�̓R�[�h
     */
    public void setIocd(String iocd) {
        this._iocd = iocd;
    }

    /**
     * ����p�r�R�[�h���擾����
     *
     * @return ����p�r�R�[�h
     */
    public String getSpusecd() {
        return _spusecd;
    }

    /**
     * ����p�r�R�[�h��ݒ肷��
     *
     * @param spusecd ����p�r�R�[�h
     */
    public void setSpusecd(String spusecd) {
        this._spusecd = spusecd;
    }

    /**
     * �g�D�R�[�h�i�{���j���擾����
     *
     * @return �g�D�R�[�h�i�{���j
     */
    public String getSikcdhonb() {
        return _sikcdhonb;
    }

    /**
     * �g�D�R�[�h�i�{���j��ݒ肷��
     *
     * @param sikcdhonb �g�D�R�[�h�i�{���j
     */
    public void setSikcdhonb(String sikcdhonb) {
        this._sikcdhonb = sikcdhonb;
    }

    /**
     * �{���\�����i�J�i�j���擾����
     *
     * @return �{���\�����i�J�i�j
     */
    public String getHonbhyojikn() {
        return _honbhyojikn;
    }

    /**
     * �{���\�����i�J�i�j��ݒ肷��
     *
     * @param honbhyojikn �{���\�����i�J�i�j
     */
    public void setHonbhyojikn(String honbhyojikn) {
        this._honbhyojikn = honbhyojikn;
    }

    /**
     * �{���\�����i�����j���擾����
     *
     * @return �{���\�����i�����j
     */
    public String getHonbhyojikj() {
        return _honbhyojikj;
    }

    /**
     * �{���\�����i�����j��ݒ肷��
     *
     * @param honbhyojikj �{���\�����i�����j
     */
    public void setHonbhyojikj(String honbhyojikj) {
        this._honbhyojikj = honbhyojikj;
    }

    /**
     * �{���\�����̂��擾����
     *
     * @return �{���\������
     */
    public String getHonbhyojiryaku() {
        return _honbhyojiryaku;
    }

    /**
     * �{���\�����̂�ݒ肷��
     *
     * @param honbhyojiryaku �{���\������
     */
    public void setHonbhyojiryaku(String honbhyojiryaku) {
        this._honbhyojiryaku = honbhyojiryaku;
    }

    /**
     * �{���\�����i�p���j���擾����
     *
     * @return �{���\�����i�p���j
     */
    public String getHonbhyojien() {
        return _honbhyojien;
    }

    /**
     * �{���\�����i�p���j��ݒ肷��
     *
     * @param honbhyojien �{���\�����i�p���j
     */
    public void setHonbhyojien(String honbhyojien) {
        this._honbhyojien = honbhyojien;
    }

    /**
     * �g�D�R�[�h�i�ǁj���擾����
     *
     * @return �g�D�R�[�h�i�ǁj
     */
    public String getSikcdkyk() {
        return _sikcdkyk;
    }

    /**
     * �g�D�R�[�h�i�ǁj��ݒ肷��
     *
     * @param sikcdkyk �g�D�R�[�h�i�ǁj
     */
    public void setSikcdkyk(String sikcdkyk) {
        this._sikcdkyk = sikcdkyk;
    }

    /**
     * �Ǖ\�����i�J�i�j���擾����
     *
     * @return �Ǖ\�����i�J�i�j
     */
    public String getKykhyojikn() {
        return _kykhyojikn;
    }

    /**
     * �Ǖ\�����i�J�i�j��ݒ肷��
     *
     * @param kykhyojikn �Ǖ\�����i�J�i�j
     */
    public void setKykhyojikn(String kykhyojikn) {
        this._kykhyojikn = kykhyojikn;
    }

    /**
     * �Ǖ\�����i�����j���擾����
     *
     * @return �Ǖ\�����i�����j
     */
    public String getKykhyojikj() {
        return _kykhyojikj;
    }

    /**
     * �Ǖ\�����i�����j��ݒ肷��
     *
     * @param kykhyojikj �Ǖ\�����i�����j
     */
    public void setKykhyojikj(String kykhyojikj) {
        this._kykhyojikj = kykhyojikj;
    }

    /**
     * �Ǖ\�����̂��擾����
     *
     * @return �Ǖ\������
     */
    public String getKykhyojiryaku() {
        return _kykhyojiryaku;
    }

    /**
     * �Ǖ\�����̂�ݒ肷��
     *
     * @param kykhyojiryaku �Ǖ\������
     */
    public void setKykhyojiryaku(String kykhyojiryaku) {
        this._kykhyojiryaku = kykhyojiryaku;
    }

    /**
     * �Ǖ\�����i�p���j���擾����
     *
     * @return �Ǖ\�����i�p���j
     */
    public String getKykhyojien() {
        return _kykhyojien;
    }

    /**
     * �Ǖ\�����i�p���j��ݒ肷��
     *
     * @param kykhyojien �Ǖ\�����i�p���j
     */
    public void setKykhyojien(String kykhyojien) {
        this._kykhyojien = kykhyojien;
    }

    /**
     * �g�D�R�[�h�i���j���擾����
     *
     * @return �g�D�R�[�h�i���j
     */
    public String getSikcdsitu() {
        return _sikcdsitu;
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肷��
     *
     * @param sikcdsitu �g�D�R�[�h�i���j
     */
    public void setSikcdsitu(String sikcdsitu) {
        this._sikcdsitu = sikcdsitu;
    }

    /**
     * ���\�����i�J�i�j���擾����
     *
     * @return ���\�����i�J�i�j
     */
    public String getSituhyojikn() {
        return _situhyojikn;
    }

    /**
     * ���\�����i�J�i�j��ݒ肷��
     *
     * @param situhyojikn ���\�����i�J�i�j
     */
    public void setSituhyojikn(String situhyojikn) {
        this._situhyojikn = situhyojikn;
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getSituhyojikj() {
        return _situhyojikj;
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param situhyojikj ���\�����i�����j
     */
    public void setSituhyojikj(String situhyojikj) {
        this._situhyojikj = situhyojikj;
    }

    /**
     * ���\�����̂��擾����
     *
     * @return ���\������
     */
    public String getSituhyojiryaku() {
        return _situhyojiryaku;
    }

    /**
     * ���\�����̂�ݒ肷��
     *
     * @param situhyojiryaku ���\������
     */
    public void setSituhyojiryaku(String situhyojiryaku) {
        this._situhyojiryaku = situhyojiryaku;
    }

    /**
     * ���\�����i�p���j���擾����
     *
     * @return ���\�����i�p���j
     */
    public String getSituhyojien() {
        return _situhyojien;
    }

    /**
     * ���\�����i�p���j��ݒ肷��
     *
     * @param situhyojien ���\�����i�p���j
     */
    public void setSituhyojien(String situhyojien) {
        this._situhyojien = situhyojien;
    }

    /**
     * �g�D�R�[�h�i���j���擾����
     *
     * @return �g�D�R�[�h�i���j
     */
    public String getSikcdbu() {
        return _sikcdbu;
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肷��
     *
     * @param sikcdbu �g�D�R�[�h�i���j
     */
    public void setSikcdbu(String sikcdbu) {
        this._sikcdbu = sikcdbu;
    }

    /**
     * ���\�����i�J�i�j���擾����
     *
     * @return ���\�����i�J�i�j
     */
    public String getBuhyojikn() {
        return _buhyojikn;
    }

    /**
     * ���\�����i�J�i�j��ݒ肷��
     *
     * @param buhyojikn ���\�����i�J�i�j
     */
    public void setBuhyojikn(String buhyojikn) {
        this._buhyojikn = buhyojikn;
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getBuhyojikj() {
        return _buhyojikj;
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param buhyojikj ���\�����i�����j
     */
    public void setBuhyojikj(String buhyojikj) {
        this._buhyojikj = buhyojikj;
    }

    /**
     * ���\�����̂��擾����
     *
     * @return ���\������
     */
    public String getBuhyojiryaku() {
        return _buhyojiryaku;
    }

    /**
     * ���\�����̂�ݒ肷��
     *
     * @param buhyojiryaku ���\������
     */
    public void setBuhyojiryaku(String buhyojiryaku) {
        this._buhyojiryaku = buhyojiryaku;
    }

    /**
     * ���\�����i�p���j���擾����
     *
     * @return ���\�����i�p���j
     */
    public String getBuhyojien() {
        return _buhyojien;
    }

    /**
     * ���\�����i�p���j��ݒ肷��
     *
     * @param buhyojien ���\�����i�p���j
     */
    public void setBuhyojien(String buhyojien) {
        this._buhyojien = buhyojien;
    }

    /**
     * �g�D�R�[�h�i�ہj���擾����
     *
     * @return �g�D�R�[�h�i�ہj
     */
    public String getSikcdka() {
        return _sikcdka;
    }

    /**
     * �g�D�R�[�h�i�ہj��ݒ肷��
     *
     * @param sikcdka �g�D�R�[�h�i�ہj
     */
    public void setSikcdka(String sikcdka) {
        this._sikcdka = sikcdka;
    }

    /**
     * �ە\�����i�J�i�j���擾����
     *
     * @return �ە\�����i�J�i�j
     */
    public String getKahyojikn() {
        return _kahyojikn;
    }

    /**
     * �ە\�����i�J�i�j��ݒ肷��
     *
     * @param kahyojikn �ە\�����i�J�i�j
     */
    public void setKahyojikn(String kahyojikn) {
        this._kahyojikn = kahyojikn;
    }

    /**
     * �ە\�����i�����j���擾����
     *
     * @return �ە\�����i�����j
     */
    public String getKahyojikj() {
        return _kahyojikj;
    }

    /**
     * �ە\�����i�����j��ݒ肷��
     *
     * @param kahyojikj �ە\�����i�����j
     */
    public void setKahyojikj(String kahyojikj) {
        this._kahyojikj = kahyojikj;
    }

    /**
     * �ە\�����̂��擾����
     *
     * @return �ە\������
     */
    public String getKahyojiryaku() {
        return _kahyojiryaku;
    }

    /**
     * �ە\�����̂�ݒ肷��
     *
     * @param kahyojiryaku �ە\������
     */
    public void setKahyojiryaku(String kahyojiryaku) {
        this._kahyojiryaku = kahyojiryaku;
    }

    /**
     * �ە\�����i�p���j���擾����
     *
     * @return �ە\�����i�p���j
     */
    public String getKahyojien() {
        return _kahyojien;
    }

    /**
     * �ە\�����i�p���j��ݒ肷��
     *
     * @param kahyojien �ە\�����i�p���j
     */
    public void setKahyojien(String kahyojien) {
        this._kahyojien = kahyojien;
    }

}
