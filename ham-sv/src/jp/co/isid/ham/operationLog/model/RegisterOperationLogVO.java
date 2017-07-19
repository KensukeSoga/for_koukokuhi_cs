package jp.co.isid.ham.operationLog.model;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj28WorkLogVO;

/**
 * <P>
 * �ғ����O�@�o�^���s���̓o�^�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/06 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.operationLog.ham.isid.co.jp/")
@XmlType(namespace = "http://model.operationLog.ham.isid.co.jp/")
public class RegisterOperationLogVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** �ғ����OVO */
    private Tbj28WorkLogVO _workLogVo = null;

    /**
     * �ғ����OVO���擾����
     *
     * @return �ғ����OVO
     */
    public Tbj28WorkLogVO getWorkLogVo() {
        return _workLogVo;
    }

    /**
     * �ғ����OVO��ݒ肷��
     * @param workLogVo �ғ����OVO
     */
    public void setWorkLogVo(Tbj28WorkLogVO workLogVo) {
        this._workLogVo = workLogVo;
    }



}
