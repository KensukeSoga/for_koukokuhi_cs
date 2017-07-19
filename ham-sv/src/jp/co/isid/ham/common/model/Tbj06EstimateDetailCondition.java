package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���ϖ��׌�������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj06EstimateDetailCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ϖ��׊Ǘ�NO */
    private BigDecimal _estdetailseqno = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �N�� */
    private Date _crdate = null;

    /** ���ψČ��Ǘ�NO */
    private BigDecimal _estseqno = null;

    /** �\�[�g�� */
    private BigDecimal _sortno = null;

    /** ���i�R�[�h */
    private String _productcd = null;

    /** ���i�� */
    private String _productnm = null;

    /** ���i��(�T�u�j */
    private String _productnmsub = null;

    /** �}�̕��ރR�[�h */
    private String _mediaclasscd = null;

    /** �}�̃R�[�h */
    private String _mediacd = null;

    /** �Ɩ����ރR�[�h */
    private String _businessclasscd = null;

    /** �Ɩ��R�[�h */
    private String _businesscd = null;

    /** �E�v */
    private String _tekiyou = null;

    /** ���{�� */
    private Date _operationdate = null;

    /** �T�C�Y�R�[�h */
    private String _sizecd = null;

    /** �T�C�Y */
    private String _size = null;

    /** ���� */
    private BigDecimal _suuryou = null;

    /** �P�ʃO���[�v�R�[�h */
    private String _unitgroupcd = null;

    /** �P�ʃO���[�v�� */
    private String _unitgroupnm = null;

    /** �P�� */
    private BigDecimal _tanka = null;

    /** �W�����z */
    private BigDecimal _hyoujun = null;

    /** �l���z */
    private BigDecimal _nebiki = null;

    /** ���ϋ��z */
    private BigDecimal _mitumori = null;

    /** �ېőΏۊz */
    private BigDecimal _kazei = null;

    /** ����Ŋz */
    private BigDecimal _syouhizei = null;

    /** ���v���z */
    private BigDecimal _goukei = null;

    /** �d������Ōv�Z�敪 */
    private String _calkbn = null;

    /** �[���t���O */
    private String _nounyuuflg = null;

    /** �o�����t���O */
    private String _dekidakaflg = null;

    /** �o�̓O���[�v */
    private String _outputgroup = null;

    /** ������O���[�v */
    private String _hcbumoncdbill = null;

    /** ������O���[�v�o�͏�SEQNO */
    private BigDecimal _hcbumoncdbillseqno = null;

    /** �f�[�^�쐬���� */
    private Date _crtdate = null;

    /** �f�[�^�쐬�� */
    private String _crtnm = null;

    /** �쐬�v���O���� */
    private String _crtapl = null;

    /** �쐬�S����ID */
    private String _crtid = null;

    /** �f�[�^�X�V���� */
    private Date _upddate = null;

    /** �f�[�^�X�V�� */
    private String _updnm = null;

    /** �X�V�v���O���� */
    private String _updapl = null;

    /** �X�V�S����ID */
    private String _updid = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj06EstimateDetailCondition() {
    }

    /**
     * ���ϖ��׊Ǘ�NO���擾����
     *
     * @return ���ϖ��׊Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstdetailseqno() {
        return _estdetailseqno;
    }

    /**
     * ���ϖ��׊Ǘ�NO��ݒ肷��
     *
     * @param estdetailseqno ���ϖ��׊Ǘ�NO
     */
    public void setEstdetailseqno(BigDecimal estdetailseqno) {
        this._estdetailseqno = estdetailseqno;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrdate() {
        return _crdate;
    }

    /**
     * �N����ݒ肷��
     *
     * @param crdate �N��
     */
    public void setCrdate(Date crdate) {
        this._crdate = crdate;
    }

    /**
     * ���ψČ��Ǘ�NO���擾����
     *
     * @return ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstseqno() {
        return _estseqno;
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     *
     * @param estseqno ���ψČ��Ǘ�NO
     */
    public void setEstseqno(BigDecimal estseqno) {
        this._estseqno = estseqno;
    }

    /**
     * �\�[�g�����擾����
     *
     * @return �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * �\�[�g����ݒ肷��
     *
     * @param sortno �\�[�g��
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * ���i�R�[�h���擾����
     *
     * @return ���i�R�[�h
     */
    public String getProductcd() {
        return _productcd;
    }

    /**
     * ���i�R�[�h��ݒ肷��
     *
     * @param productcd ���i�R�[�h
     */
    public void setProductcd(String productcd) {
        this._productcd = productcd;
    }

    /**
     * ���i�����擾����
     *
     * @return ���i��
     */
    public String getProductnm() {
        return _productnm;
    }

    /**
     * ���i����ݒ肷��
     *
     * @param productnm ���i��
     */
    public void setProductnm(String productnm) {
        this._productnm = productnm;
    }

    /**
     * ���i��(�T�u�j���擾����
     *
     * @return ���i��(�T�u�j
     */
    public String getProductnmsub() {
        return _productnmsub;
    }

    /**
     * ���i��(�T�u�j��ݒ肷��
     *
     * @param productnmsub ���i��(�T�u�j
     */
    public void setProductnmsub(String productnmsub) {
        this._productnmsub = productnmsub;
    }

    /**
     * �}�̕��ރR�[�h���擾����
     *
     * @return �}�̕��ރR�[�h
     */
    public String getMediaclasscd() {
        return _mediaclasscd;
    }

    /**
     * �}�̕��ރR�[�h��ݒ肷��
     *
     * @param mediaclasscd �}�̕��ރR�[�h
     */
    public void setMediaclasscd(String mediaclasscd) {
        this._mediaclasscd = mediaclasscd;
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param mediacd �}�̃R�[�h
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * �Ɩ����ރR�[�h���擾����
     *
     * @return �Ɩ����ރR�[�h
     */
    public String getBusinessclasscd() {
        return _businessclasscd;
    }

    /**
     * �Ɩ����ރR�[�h��ݒ肷��
     *
     * @param businessclasscd �Ɩ����ރR�[�h
     */
    public void setBusinessclasscd(String businessclasscd) {
        this._businessclasscd = businessclasscd;
    }

    /**
     * �Ɩ��R�[�h���擾����
     *
     * @return �Ɩ��R�[�h
     */
    public String getBusinesscd() {
        return _businesscd;
    }

    /**
     * �Ɩ��R�[�h��ݒ肷��
     *
     * @param businesscd �Ɩ��R�[�h
     */
    public void setBusinesscd(String businesscd) {
        this._businesscd = businesscd;
    }

    /**
     * �E�v���擾����
     *
     * @return �E�v
     */
    public String getTekiyou() {
        return _tekiyou;
    }

    /**
     * �E�v��ݒ肷��
     *
     * @param tekiyou �E�v
     */
    public void setTekiyou(String tekiyou) {
        this._tekiyou = tekiyou;
    }

    /**
     * ���{�����擾����
     *
     * @return ���{��
     */
    @XmlElement(required = true, nillable = true)
    public Date getOperationdate() {
        return _operationdate;
    }

    /**
     * ���{����ݒ肷��
     *
     * @param operationdate ���{��
     */
    public void setOperationdate(Date operationdate) {
        this._operationdate = operationdate;
    }

    /**
     * �T�C�Y�R�[�h���擾����
     *
     * @return �T�C�Y�R�[�h
     */
    public String getSizecd() {
        return _sizecd;
    }

    /**
     * �T�C�Y�R�[�h��ݒ肷��
     *
     * @param sizecd �T�C�Y�R�[�h
     */
    public void setSizecd(String sizecd) {
        this._sizecd = sizecd;
    }

    /**
     * �T�C�Y���擾����
     *
     * @return �T�C�Y
     */
    public String getSize() {
        return _size;
    }

    /**
     * �T�C�Y��ݒ肷��
     *
     * @param size �T�C�Y
     */
    public void setSize(String size) {
        this._size = size;
    }

    /**
     * ���ʂ��擾����
     *
     * @return ����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSuuryou() {
        return _suuryou;
    }

    /**
     * ���ʂ�ݒ肷��
     *
     * @param suuryou ����
     */
    public void setSuuryou(BigDecimal suuryou) {
        this._suuryou = suuryou;
    }

    /**
     * �P�ʃO���[�v�R�[�h���擾����
     *
     * @return �P�ʃO���[�v�R�[�h
     */
    public String getUnitgroupcd() {
        return _unitgroupcd;
    }

    /**
     * �P�ʃO���[�v�R�[�h��ݒ肷��
     *
     * @param unitgroupcd �P�ʃO���[�v�R�[�h
     */
    public void setUnitgroupcd(String unitgroupcd) {
        this._unitgroupcd = unitgroupcd;
    }

    /**
     * �P�ʃO���[�v�����擾����
     *
     * @return �P�ʃO���[�v��
     */
    public String getUnitgroupnm() {
        return _unitgroupnm;
    }

    /**
     * �P�ʃO���[�v����ݒ肷��
     *
     * @param unitgroupnm �P�ʃO���[�v��
     */
    public void setUnitgroupnm(String unitgroupnm) {
        this._unitgroupnm = unitgroupnm;
    }

    /**
     * �P�����擾����
     *
     * @return �P��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTanka() {
        return _tanka;
    }

    /**
     * �P����ݒ肷��
     *
     * @param tanka �P��
     */
    public void setTanka(BigDecimal tanka) {
        this._tanka = tanka;
    }

    /**
     * �W�����z���擾����
     *
     * @return �W�����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHyoujun() {
        return _hyoujun;
    }

    /**
     * �W�����z��ݒ肷��
     *
     * @param hyoujun �W�����z
     */
    public void setHyoujun(BigDecimal hyoujun) {
        this._hyoujun = hyoujun;
    }

    /**
     * �l���z���擾����
     *
     * @return �l���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNebiki() {
        return _nebiki;
    }

    /**
     * �l���z��ݒ肷��
     *
     * @param nebiki �l���z
     */
    public void setNebiki(BigDecimal nebiki) {
        this._nebiki = nebiki;
    }

    /**
     * ���ϋ��z���擾����
     *
     * @return ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMitumori() {
        return _mitumori;
    }

    /**
     * ���ϋ��z��ݒ肷��
     *
     * @param mitumori ���ϋ��z
     */
    public void setMitumori(BigDecimal mitumori) {
        this._mitumori = mitumori;
    }

    /**
     * �ېőΏۊz���擾����
     *
     * @return �ېőΏۊz
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getKazei() {
        return _kazei;
    }

    /**
     * �ېőΏۊz��ݒ肷��
     *
     * @param kazei �ېőΏۊz
     */
    public void setKazei(BigDecimal kazei) {
        this._kazei = kazei;
    }

    /**
     * ����Ŋz���擾����
     *
     * @return ����Ŋz
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSyouhizei() {
        return _syouhizei;
    }

    /**
     * ����Ŋz��ݒ肷��
     *
     * @param syouhizei ����Ŋz
     */
    public void setSyouhizei(BigDecimal syouhizei) {
        this._syouhizei = syouhizei;
    }

    /**
     * ���v���z���擾����
     *
     * @return ���v���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGoukei() {
        return _goukei;
    }

    /**
     * ���v���z��ݒ肷��
     *
     * @param goukei ���v���z
     */
    public void setGoukei(BigDecimal goukei) {
        this._goukei = goukei;
    }

    /**
     * �d������Ōv�Z�敪���擾����
     *
     * @return �d������Ōv�Z�敪
     */
    public String getCalkbn() {
        return _calkbn;
    }

    /**
     * �d������Ōv�Z�敪��ݒ肷��
     *
     * @param calkbn �d������Ōv�Z�敪
     */
    public void setCalkbn(String calkbn) {
        this._calkbn = calkbn;
    }

    /**
     * �[���t���O���擾����
     *
     * @return �[���t���O
     */
    public String getNounyuuflg() {
        return _nounyuuflg;
    }

    /**
     * �[���t���O��ݒ肷��
     *
     * @param nounyuuflg �[���t���O
     */
    public void setNounyuuflg(String nounyuuflg) {
        this._nounyuuflg = nounyuuflg;
    }

    /**
     * �o�����t���O���擾����
     *
     * @return �o�����t���O
     */
    public String getDekidakaflg() {
        return _dekidakaflg;
    }

    /**
     * �o�����t���O��ݒ肷��
     *
     * @param dekidakaflg �o�����t���O
     */
    public void setDekidakaflg(String dekidakaflg) {
        this._dekidakaflg = dekidakaflg;
    }

    /**
     * �o�̓O���[�v���擾����
     *
     * @return �o�̓O���[�v
     */
    public String getOutputgroup() {
        return _outputgroup;
    }

    /**
     * �o�̓O���[�v��ݒ肷��
     *
     * @param outputgroup �o�̓O���[�v
     */
    public void setOutputgroup(String outputgroup) {
        this._outputgroup = outputgroup;
    }

    /**
     * ������O���[�v���擾����
     *
     * @return ������O���[�v
     */
    public String getHcbumoncdbill() {
        return _hcbumoncdbill;
    }

    /**
     * ������O���[�v��ݒ肷��
     *
     * @param hcbumoncdbill ������O���[�v
     */
    public void setHcbumoncdbill(String hcbumoncdbill) {
        this._hcbumoncdbill = hcbumoncdbill;
    }

    /**
     * ������O���[�v�o�͏�SEQNO���擾����
     *
     * @return ������O���[�v�o�͏�SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHcbumoncdbillseqno() {
        return _hcbumoncdbillseqno;
    }

    /**
     * ������O���[�v�o�͏�SEQNO��ݒ肷��
     *
     * @param hcbumoncdbillseqno ������O���[�v�o�͏�SEQNO
     */
    public void setHcbumoncdbillseqno(BigDecimal hcbumoncdbillseqno) {
        this._hcbumoncdbillseqno = hcbumoncdbillseqno;
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param crtdate �f�[�^�쐬����
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCrtnm() {
        return _crtnm;
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param crtnm �f�[�^�쐬��
     */
    public void setCrtnm(String crtnm) {
        this._crtnm = crtnm;
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCrtapl() {
        return _crtapl;
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param crtapl �쐬�v���O����
     */
    public void setCrtapl(String crtapl) {
        this._crtapl = crtapl;
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCrtid() {
        return _crtid;
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param crtid �쐬�S����ID
     */
    public void setCrtid(String crtid) {
        this._crtid = crtid;
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param upddate �f�[�^�X�V����
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param updnm �f�[�^�X�V��
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
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
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param updid �X�V�S����ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
