package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �`�F�b�N���X�g�@�f�[�^�擾�̏����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetRepDataForChkListCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** �y�Ɩ���v�z���Ӑ�R�[�h */
    private String[] _tokuisakiCdList = null;

    /** �y�Ɩ���v�z�o�͏��i0:��No�A1:�S���ҁj */
    private int _orderKbn = 0;

    /** �y�Ɩ���v�z����From */
    private Date _fromDate = null;

    /** �y�Ɩ���v�z����To */
    private Date _toDate = null;

    /** �y�Ɩ���v�z�����ǃR�[�h */
    private String[] _kyokuCdList = null;

    /** �y�Ɩ���v�z�S���҃R�[�h */
    private String[] _tntCdList = null;

    /** �y�Ɩ���n�z�c�Ɠ� */
    private String _eigyobi = null;


    /** �t�F�C�Y */
    private int _phase = 0;

    /** �N��(From) */
    private Date _fromSeikyuDate = null;

    /** �N��(To) */
    private Date _toSeikyuDate = null;

    /** �Ԏ탊�X�g */
    private String[] _carList = null;

    /**
     * �c�Ə��R�[�h
     */
    private String _egsCd = null;

    /**
     * ���Ӑ�R�[�h���擾����
     *
     * @return ���Ӑ�R�[�h
     */
    @XmlElement(required = true)
    public String[] getTokuisakiCdList() {
        return _tokuisakiCdList;
    }

    /**
     * ���Ӑ�R�[�h��ݒ肷��
     *
     * @param tokuisakiCd ���Ӑ�R�[�h
     */
    public void setTokuisakiCdList(String[] tokuisakiCdList) {
        this._tokuisakiCdList = tokuisakiCdList;
    }

    /**
     * �o�͏����擾����
     *
     * @return �o�͏�
     */
    public int getOrderKbn() {
        return _orderKbn;
    }

    /**
     * �o�͏���ݒ肷��
     *
     * @param orderKbn �o�͏�
     */
    public void setOrderKbn(int orderKbn) {
        this._orderKbn = orderKbn;
    }

    /**
     * ����From���擾����
     *
     * @return ����From
     */
    @XmlElement(required = true)
    public Date getFromDate() {
        return _fromDate;
    }

    /**
     * ����From��ݒ肷��
     *
     * @param fromDate ����From
     */
    public void setFromDate(Date fromDate) {
        this._fromDate = fromDate;
    }

    /**
     * ����To���擾����
     *
     * @return ����To
     */
    @XmlElement(required = true)
    public Date getToDate() {
        return _toDate;
    }

    /**
     * ����To��ݒ肷��
     *
     * @param toDate ����To
     */
    public void setToDate(Date toDate) {
        this._toDate = toDate;
    }

    /**
     * �����ǃR�[�h���擾����
     *
     * @return �����ǃR�[�h
     */
    @XmlElement(required = true)
    public String[] getKyokuCdList() {
        return _kyokuCdList;
    }

    /**
     * �����ǃR�[�h��ݒ肷��
     *
     * @param kyokuCdList �����ǃR�[�h
     */
    public void setKyokuCdList(String[] kyokuCdList) {
        this._kyokuCdList = kyokuCdList;
    }

    /**
     * �S���҃R�[�h���擾����
     *
     * @return �S���҃R�[�h
     */
    @XmlElement(required = true)
    public String[] getTntCdList() {
        return _tntCdList;
    }

    /**
     * �S���҃R�[�h��ݒ肷��
     *
     * @param tntCdList �S���҃R�[�h
     */
    public void setTntCdList(String[] tntCdList) {
        this._tntCdList = tntCdList;
    }

    /**
     * �c�Ɠ����擾����
     *
     * @return �c�Ɠ�
     */
    public String getEigyobi() {
        return _eigyobi;
    }

    /**
     * �c�Ɠ���ݒ肷��
     *
     * @param eigyobi �c�Ɠ�
     */
    public void setEigyobi(String eigyobi) {
        _eigyobi = eigyobi;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return phase
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param phase phase
     */
    public void setPhase(int phase) {
        this._phase = phase;
    }

    /**
     * �N��(From)���擾����
     *
     * @return fromDate
     */
    @XmlElement(required = true, nillable = true)
    public Date getFromSeikyuDate() {
        return _fromSeikyuDate;
    }

    /**
     * �N��(From)��ݒ肷��
     * @param fromDate �N��(From)
     */
    public void setFromSeikyuDate(Date fromSeikyuDate) {
        this._fromSeikyuDate = fromSeikyuDate;
    }

    /**
     * �N��(To)���擾����
     *
     * @return �N��(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getToSeikyuDate() {
        return _toSeikyuDate;
    }

    /**
     * �N��(To)��ݒ肷��
     * @param toDate �N��(To)
     */
    public void setToSeikyuDate(Date toSeikyuDate) {
        this._toSeikyuDate = toSeikyuDate;
    }

    /**
     * �Ԏ탊�X�g���擾����
     *
     * @return carList
     */
    public String[] getCarList() {
        return _carList;
    }

    /**
     * �Ԏ탊�X�g��ݒ肷��
     * @param carList �Ԏ탊�X�g
     */
    public void setCarList(String[] carList) {
        this._carList = carList;
    }

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return _egsCd
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     * @param egsCd _egsCd
     */
    public void setEgsCd(String egsCd) {
        _egsCd = egsCd;
    }
}
