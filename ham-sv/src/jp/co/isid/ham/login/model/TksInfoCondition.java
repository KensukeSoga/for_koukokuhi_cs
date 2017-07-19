package jp.co.isid.ham.login.model;

import java.io.Serializable;

public class TksInfoCondition implements Serializable{

	private static final long serialVersionUID = 4082004138863641700L;

    /** �c�Ə��R�[�h */
    private String _egsCd = null;

    /** ���Ӑ��ƃR�[�h */
    private String _tksKgyCd = null;

    /** ���Ӑ敔��SEQNO */
    private String _tksBmnSeqNo = null;

	/** �c�Ɠ� */
	private String _eigyobi = null;

    /** �g�D�R�[�h */
    private String _sikcd = null;

    /**
     * �c�Ə��R�[�h���擾����
     * @return �c�Ə��R�[�h
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     * @param egsCd �c�Ə��R�[�h
     */
    public void setEgsCd(String egsCd) {
        this._egsCd = egsCd;
    }

    /**
     * ���Ӑ��ƃR�[�h���擾����
     * @return ���Ӑ��ƃR�[�h
     */
    public String getTksKgyCd() {
        return _tksKgyCd;
    }

    /**
     * ���Ӑ��ƃR�[�h��ݒ肷��
     * @param tksKgyCd ���Ӑ��ƃR�[�h
     */
    public void setTksKgyCd(String tksKgyCd) {
        this._tksKgyCd = tksKgyCd;
    }

    /**
     * ���Ӑ敔��SEQNO���擾����
     * @return ���Ӑ敔��SEQNO
     */
    public String getTksBmnSeqNo() {
        return _tksBmnSeqNo;
    }

    /**
     * ���Ӑ敔��SEQNO��ݒ肷��
     * @param tksBmnSeqNo ���Ӑ敔��SEQNO
     */
    public void setTksBmnSeqNo(String tksBmnSeqNo) {
        this._tksBmnSeqNo = tksBmnSeqNo;
    }

	/**
	 * �c�Ɠ����擾����
	 * @return �c�Ɠ�
	 */
	public String getEigyobi() {
	    return _eigyobi;
	}

	/**
	 * �c�Ɠ���ݒ肷��
	 * @param eigyobi �c�Ɠ�
	 */
	public void setEigyobi(String eigyobi) {
	    this._eigyobi = eigyobi;
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
}
