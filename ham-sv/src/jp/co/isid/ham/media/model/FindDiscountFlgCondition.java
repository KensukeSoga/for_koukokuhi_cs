package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

public class FindDiscountFlgCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �����R�[�h */
    private String _thskgycd;

    /** SEQNO */
    private String _seqNo;

    /** ����S��SEQNO */
    private String _trtntSeqNo;

    /** ���ԊJ�n */
    private BigDecimal _kikanFrom;

    /** ���ԏI�� */
    private BigDecimal _kikanTo;

    /** �V�G�}�̃R�[�h */
    private String _mediaCd;

    /** ���ŃR�[�h */
    private String _kbanCd;

    /** �Ɩ��敪 */
    private String _workFlg;

    /** �c�ƍ�Ƒ䒠No */
    private String _daichoNo;

    /** ��� */
    private String _items;

    /**
     * �����R�[�h�擾
     * @return �����R�[�h
     */
    public String getThskgycd() {
       return _thskgycd;
    }

    /**
     * �����R�[�h�ݒ�
     * @param thskgycd
     */
    public void setThskgycd(String thskgycd) {
        this._thskgycd = thskgycd;
    }

    /**
     * SEQNO�擾
     * @return SEQNO�ݒ�
     */
    public String getSeqNo() {
        return _seqNo;
    }

    /**
     * SEQNO�ݒ�
     * @param seqNo
     */
    public void setSeqNo(String seqNo) {
        this._seqNo = seqNo;
    }

    /**
     * ����S��SEQNO�擾
     * @return
     */
    public String getTrtntSeqNo() {
        return _trtntSeqNo;
    }

    /**
     * ����S��SEQNO�ݒ�
     * @param trtntSeqNo
     */
    public void setTrtntSeqNo(String trtntSeqNo) {
        this._trtntSeqNo = trtntSeqNo;
    }

    /**
     * ���ԊJ�n�擾
     * @return
     */
    @XmlElement(required = true)
    public BigDecimal getKikanFrom() {
        return _kikanFrom;
    }

    /**
     * ���ԊJ�n�ݒ�
     * @param kikanFrom
     */
    public void setKikanFrom(BigDecimal kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * ���ԏI���擾
     * @return
     */
    @XmlElement(required = true)
    public BigDecimal getKikanTo() {
        return _kikanTo;
    }

    /**
     * ���ԏI���ݒ�
     * @param kikanTo
     */
    public void setKikanTo(BigDecimal kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * �V�G�}�̃R�[�h�擾
     * @return
     */
    public String getMediaCd() {
        return _mediaCd;
    }

    /**
     * �V�G�}�̃R�[�h�ݒ�
     * @param mediaCd
     */
    public void setMediaCd(String mediaCd) {
        this._mediaCd = mediaCd;
    }

    /**
     * ���ŃR�[�h�擾
     * @return
     */
    public String getKbanCd() {
        return _kbanCd;
    }

    /**
     * ���ŃR�[�h�ݒ�
     * @param kbanCd
     */
    public void setKbanCd(String kbanCd) {
        this._kbanCd = kbanCd;
    }

    /**
     * �Ɩ��敪�擾
     * @return
     */
    public String getWorkFlg() {
        return _workFlg;
    }

    /**
     * �Ɩ��敪�ݒ�
     * @param workFlg
     */
    public void setWorkFlg(String workFlg) {
        this._workFlg = workFlg;
    }

    /**
     * �c�Ƒ䒠No���擾
     * @return
     */
    public String getDaichoNo() {
        return _daichoNo;
    }

    /**
     * �c�Ƒ䒠No��ݒ�
     * @param daichoNo
     */
    public void setDaichoNo(String daichoNo) {
        this._daichoNo = daichoNo;
    }

    /**
     * ��ڂ��擾
     * @return
     */
    public String getItems() {
        return _items;
    }

    /**
     * ��ڂ�ݒ�
     * @param items
     */
    public void setItem(String items) {
        this._items = items;
    }
}
